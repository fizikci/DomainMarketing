<div class="page-header">
    <h1 class="blue">
        <i class="icon-gamepad"></i>
        Property Set
    <small>
        <i class="icon-double-angle-right"></i>
        Property lists assignable to any type of entity
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



        <div class="widget-box transparent" id="recent-box">
            <div class="widget-header">
                <div class="widget-toolbar no-border">
                    <ul class="nav nav-tabs" id="recent-tab">
                        <li class="{{tab=='props' ? 'active':''}}">
                            <a ng-click="tab='props'"><i class="icon-map-marker blue"></i>Properties</a>
                        </li>
                    </ul>
                </div>
            </div>

            <div class="widget-body">
                <div class="widget-main padding-4">
                    <div class="tab-content padding-8 overflow-visible">
                            
                        <div class="tab-pane{{tab=='props' ? 'active':''}}" style="position:relative">



			                <div ng-if="!currProp">
			                    <table ng-if="props" class="table table-bordered table-hover" style="margin-top: 20px">
                                    <tbody ng-repeat="groupProps in props | groupBy: 'GroupName' | toArray:true | orderBy:min">
                                    <tr style="background: honeydew;"><td colspan="10"><b>{{groupProps.$key || ''}}</b></td></tr>
			                        <tr ng-repeat="pp in groupProps | orderBy:'OrderNo'" ng-class="{deleted:pp.IsDeleted}">
			                            <td>
			                                <i class="icon-ok green"></i>
			                                {{pp.Name}}
			                            </td>
                                        <td>{{pp.DefaultValue | limitTo:20}}</td>
			                            <td>
			                                <i class="icon-edit orange" ng-click="editProp(pp)"></i>
			                                <i class="icon-trash red" ng-click="deleteProp(pp)"></i>
                                            <i class="icon-long-arrow-up green" ng-click="upProp(pp)"></i>
                                            <i class="icon-long-arrow-down green" ng-click="downProp(pp)"></i>
			                            </td>
			                        </tr>
                                    </tbody>
			                    </table>
                                <div class="text-right">
			                        <a class="btn btn-link" ng-click="newProp()">
			                            <i class="icon-plus bigger-110"></i>
			                            Add property
			                        </a>
			                    </div>
                            </div>
                    
			                <div ng-if="currProp">
			                    <form class="form-horizontal" role="form" autocomplete="off">
			                        <input type="text" ng-model="currProp.Id" name="Id" style="display:none"/>
			                        <input type="text" ng-model="currProp.PropertySetId" name="PropertySetId" style="display:none"/>
			                        <div class="row">
			                            <input-text label="Group" model="currProp.GroupName"></input-text>
			                            <input-text label="Name" model="currProp.Name"></input-text>
			                            <input-select label="Type" model="currProp.PropType" options="i for i in ['string','options','int','date','bool','money']"></input-select>
                                        <input-text ng-show="currProp.PropType=='options'" label="Options" model="currProp.Options"></input-text>
                                        <input-text label="Default" model="currProp.DefaultValue"></input-text>
			                            <input-check label="Public" model="currProp.Public"></input-check>
			                        </div>

			                        <div class="clearfix form-actions">
			                            <div class="text-right">
			                                <button class="btn btn-xs btn-primary" type="button" ng-click="saveProp()">
			                                    <i class="icon-ok bigger-110"></i>
			                                    Save
			                                </button>
			                                &nbsp; 
			                                <button class="btn btn-xs btn-info" type="button" ng-click="cancelEditProp()">
			                                    <i class="icon-undo bigger-110"></i>
			                                    Cancel
			                                </button>
			                            </div>
			                        </div>

			                    </form>
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

