<div class="page-header">
    <h1 class="blue">
        <i class="icon-gamepad"></i>
        Product Type
    <small>
        <i class="icon-double-angle-right"></i>
        View product type details
    </small>
    </h1>
</div>

<div id="user-profile-1" class="user-profile row">
    <div class="col-xs-12 col-sm-3 center">
        <div>
            <span class="profile-picture">
                <i class="icon-gamepad" style="font-size:50px"></i>
            </span>

            <div class="space-4"></div>

            <div class="width-80 label label-info label-xlg arrowed-in arrowed-in-right">
                <div class="inline position-relative">
                    <a class="user-title-label dropdown-toggle" data-toggle="dropdown">
                        <i class="icon-circle light-green"></i>
                        &nbsp;
                                <span class="white">{{entity.Name}}</span>
                    </a>

                    <ul class="align-left dropdown-menu dropdown-caret dropdown-lighter">
                        <li class="dropdown-header">Process </li>

                        <li>
                            <a href="#/Edit/ProductType/{{entity.Id}}">
                                <i class="icon-pencil green"></i>
                                &nbsp;
		                                <span class="green">Edit</span>
                            </a>
                        </li>

                        <li>
                            <a href="#">
                                <i class="icon-trash red"></i>
                                &nbsp;
		                            <span class="red">Archive</span>
                            </a>
                        </li>

                    </ul>
                </div>
            </div>

            <div class="space-4"></div>

            <small class="block">
                <!--<span class="orange">Type: </span>{{entity.ProductType}}<br>-->
            </small>

        </div>

        <div class="hr hr16 dotted"></div>
    </div>

    <div class="col-xs-12 col-sm-9">

        <div class="profile-user-info profile-user-info-striped">
            <div class="profile-info-row">
                <div class="profile-info-name">Name </div>

                <div class="profile-info-value">
                    {{entity.Name}}
                </div>
            </div>

        </div>



        <div class="widget-box transparent" id="recent-box" ng-init="tab='products'">
            <div class="widget-header">
                <div class="widget-toolbar no-border">
                    <ul class="nav nav-tabs" id="recent-tab">
                        <li class="{{tab=='products' ? 'active':''}}">
                            <a ng-click="tab='products'"><i class="icon-envelope-alt red"></i>Products</a>
                        </li>
                        <li class="{{tab=='props' ? 'active':''}}">
                            <a ng-click="tab='props'"><i class="icon-map-marker blue"></i>Properties</a>
                        </li>
                    </ul>
                </div>
            </div>

            <div class="widget-body">
                <div class="widget-main padding-4">
                    <div class="tab-content padding-8 overflow-visible">
                            
                        <div class="tab-pane{{tab=='products' ? 'active':''}}">

                            <div ng-controller="ViewDetailListController" ng-init="entityName='Product'; where='ProductTypeId = '">
                                <page-size ng-show="count/pageSize>1"></page-size>
                                <pagination ng-show="count/pageSize>1"></pagination>
                                <table class="table table-striped table-bordered table-hover dataTable" aria-describedby="table-storage_info">
                                    <tr>
                                        <th>#</th>
                                        <th column-header="Name" field="Name"></th>
                                        <th></th>
                                    </tr>
                                    <tr ng-repeat="entity in list" ng-class="{deleted:entity.IsDeleted}">
                                        <td indexer></td>
                                        <td link-to-view>{{entity.Name}}</td>
                                        <td operations></td>
                                    </tr>
                                </table>
                            </div>


                        </div>


                        <div class="tab-pane{{tab=='props' ? 'active':''}}" style="position:relative">
                            <table class="table table-bordered table-hover" aria-describedby="table-storage_info">
                                <tbody ng-repeat="groupProps in props | groupBy: 'PropertyGroupName' | toArray:true | orderBy:min">
                                <tr style="background: honeydew;"><td colspan="3"><b>{{groupProps.$key || ''}}</b></td></tr>
                                <tr ng-repeat="p in groupProps | orderBy:'OrderNo'" ng-class="{deleted:p.IsDeleted}">
                                    <td> &nbsp; - &nbsp; {{p.PropertyName}}</td>
                                    <td>
                                        <span ng-click="editProp(entity, p)">
                                            <b>{{p.Value}}</b>
                                            <i ng-show="!p.Value">{{p.PropertyDefaultValue}}</i>
                                            <i class="icon-pencil green"></i>
                                        </span>
                                    </td>
                                </tr>
                                </tbody>
                            </table>
                            <div id="propEdit" class="dialog" ng-show="entity.currProp">
                                {{entity.currProp.PropertyName}}<br />
                                <input ng-if="entity.currProp.PropertyType=='string'" ng-model="entity.currProp.Value" class="form-control" type="text"/>
                                <select ng-if="entity.currProp.PropertyType=='options'" ng-model="entity.currProp.Value" class="form-control" ng-options="i for i in entity.currProp.PropertyOptions.split(',')"></select>
                                <input ng-if="entity.currProp.PropertyType=='int'" ng-model="entity.currProp.Value" class="form-control" type="number"/>
                                <input ng-if="entity.currProp.PropertyType=='date'" ng-model="entity.currProp.Value" class="form-control" type="date"/>
                                <select ng-if="entity.currProp.PropertyType=='bool'" ng-model="entity.currProp.Value" class="form-control" ng-options="i for i in [0,1]"></select>
                                <input ng-if="entity.currProp.PropertyType=='money'" ng-model="entity.currProp.Value" class="form-control" type="number"/>
                                <br />
                                <button class="btn btn-primary" ng-click="saveProp(entity)">Save</button>
                                <button class="btn btn-default" ng-click="cancelEditProp(entity)">Cancel</button>
                            </div>
                        </div>

                    </div>

                </div>
            </div>
            <!-- /widget-main -->
        </div>
        <!-- /widget-body -->
    </div>
</div>

