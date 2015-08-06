<div class="page-header">
    <h1 class="blue">
        <i class="icon-tag"></i>
        MDF
    <small>
        <i class="icon-double-angle-right"></i>
        Marketting Development Framework
    </small>
    </h1>
</div>

<div id="user-profile-1" class="user-profile row">
    <div class="col-xs-12 col-sm-3 center">
        <div>
            <span class="profile-picture">
                <i class="icon-tag" style="font-size: 50px"></i>
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
                            <a href="#/Edit/{{entityName}}/{{entity.Id}}">
                                <i class="icon-pencil green"></i>
                                &nbsp;
		                                <span class="green">Edit</span>
                            </a>
                        </li>
                        <li>
                            <a ng-click="copy()">
                                <i class="icon-pencil blue"></i>
                                &nbsp;
		                                <span class="blue">Copy</span>
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


        </div>

        <div class="hr hr16 dotted"></div>
    </div>

    <div class="col-xs-12 col-sm-9">

        <div class="profile-user-info profile-user-info-striped">
            <info-row label="Name">{{entity.Name}} <input-lang field-name="Name"></input-lang> </info-row>
            <info-row label="Description">{{entity.Description}} <input-lang field-name="Description"></input-lang></info-row>
            <info-row label="Text">{{entity.MdfText}} <input-lang field-name="MdfText"></input-lang></info-row>
            <info-row label="Announce">{{entity.StartDate | date:'dd-MM-yyyy'}} - {{entity.EndDate | date:'dd-MM-yyyy'}}</info-row>
            <info-row label="Validity">{{entity.AnnounceStartDate | date:'dd-MM-yyyy'}} - {{entity.AnnounceEndDate | date:'dd-MM-yyyy'}}</info-row>
            <info-row label="CountryId">{{entity.CountryId}}</info-row>
            <info-row label="ResellerTypeId">{{entity.ResellerTypeId}}</info-row>
            <info-row label="RebateRate">{{entity.RebateRate}}</info-row>
            <info-row label="RebateAmount">{{entity.RebateAmount}}</info-row>
            <info-row label="LimitBottom">{{entity.LimitBottom}}</info-row>
            <info-row label="LimitTop">{{entity.LimitTop}}</info-row>
            <div style="clear:both"></div>
        </div>



        <div class="widget-box transparent" id="recent-box">
            <div class="widget-header">
                <div class="widget-toolbar no-border">
                    <ul class="nav nav-tabs" id="recent-tab">
                        <li class="{{tab=='products' ? 'active':''}}">
                            <a ng-click="tab='products'"><i class="icon-gamepad red"></i>Products</a>
                        </li>
                        <li class="{{tab=='transactions' ? 'active':''}}">
                            <a ng-click="tab='transactions'"><i class="icon-money red"></i>Transactions</a>
                        </li>
                        <li class="{{tab=='resellers' ? 'active':''}}">
                            <a ng-click="tab='resellers'"><i class="icon-accept red"></i>Applying Resellers</a>
                        </li>
                    </ul>
                </div>
            </div>

            <div class="widget-body">
                <div class="widget-main padding-4">
                    <div class="tab-content padding-8 overflow-visible">

                        <div class="tab-pane{{tab=='products' ? 'active':''}}">
                            <div ng-controller="ViewDetailListController" ng-init="entityName='MdfProduct'; where='MdfId = '">
                                <page-size ng-show="count/pageSize>1"></page-size>
                                <pagination ng-show="count/pageSize>1"></pagination>
                                <table class="table table-striped table-bordered table-hover dataTable" aria-describedby="table-storage_info">
                                    <tr>
                                        <th>#</th>
                                        <th column-header="Product" field="ProductName"></th>
                                        <th></th>
                                    </tr>
                                    <tr ng-repeat="entity in list" ng-class="{deleted:entity.IsDeleted}">
                                        <td indexer></td>
                                        <td link-to-parent="Product">{{entity.ProductName}}</td>
                                        <td operations edit="off"></td>
                                    </tr>
                                </table>
                            </div>
                            <div class="clearfix form-actions">
                                <form id="form" class="form-inline" role="form" autocomplete="off">
                                    <input-select noemptyoption="1" horizontal="yes" label="Product" model="selectedProduct" options="i.Id as i.Name for i in Products"></input-select>
                                    <input type="button" value="Add" ng-click="addProduct()" />
                                </form>
                            </div>
                        </div>
                        <div class="tab-pane{{tab=='transactions' ? 'active':''}}">
                            <div ng-controller="ViewDetailListController" ng-init="entityName='MemberTransaction'; where='RelatedEntityName = Mdf AND RelatedEntityId = '">
                                <page-size ng-show="count/pageSize>1"></page-size>
                                <pagination ng-show="count/pageSize>1"></pagination>
                                <table class="table table-striped table-bordered table-hover dataTable" aria-describedby="table-storage_info">
                                    <tr>
                                        <th>#</th>
                                        <th column-header="Member" field="MemberName"></th>
                                        <th column-header="Amount" field="Amount"></th>
                                        <th column-header="Date" field="InsertDate"></th>
                                        <th></th>
                                    </tr>
                                    <tr ng-repeat="entity in list" ng-class="{deleted:entity.IsDeleted}">
                                        <td indexer></td>
                                        <td link-to-parent="Member">{{entity.MemberName}}</td>
                                        <td>{{entity.Amount/100 | currency}}</td>
                                        <td>{{entity.InsertDate | date}}</td>
                                        <td operations edit="off"></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="tab-pane{{tab=='resellers' ? 'active':''}}">
                            <div ng-controller="ViewDetailListMDFResellerController" ng-init="entityName='MdfReseller'; where='MdfId = '">
                                <page-size ng-show="count/pageSize>1"></page-size>
                                <pagination ng-show="count/pageSize>1"></pagination>
                                <table class="table table-striped table-bordered table-hover dataTable" aria-describedby="table-storage_info">
                                    <tr>
                                        <th>#</th>
                                        <th column-header="Reseller" field="ResellerName"></th>
                                        <th column-header="Statu" field="State"></th>
                                        <th></th>
                                    </tr>
                                    <tr ng-repeat="entity in list" ng-class="{deleted:entity.IsDeleted}">
                                        <td indexer></td>
                                        <td link-to-parent="Reseller">{{entity.ResellerName}}</td>
                                        <td>
                                            <div class="inline position-relative">

                                                <a class="user-title-label dropdown-toggle" data-toggle="dropdown">{{entity.State}}
                                                    <img src="/Assets/images/icons/down.png" /></a>

                                                <ul class="align-left dropdown-menu dropdown-caret dropdown-lighter">
                                                    <li>&nbsp;
                                                        <i class="icon-circle black"></i>
                                                        &nbsp;
                                                        <span ng-click="changeState(entity,'None')">None</span>
                                                    </li>
                                                    <li>&nbsp;
                                                        <i class="icon-circle orange"></i>
                                                        &nbsp;
                                                        <span ng-click="changeState(entity,'Waiting')">Waiting</span>
                                                    </li>
                                                    <li>&nbsp;
                                                        <i class="icon-circle green"></i>
                                                        &nbsp;
                                                        <span ng-click="changeState(entity,'Confirmed')">Confirmed</span>
                                                    </li>
                                                    <li>&nbsp;
                                                        <i class="icon-circle red"></i>
                                                        &nbsp;
                                                        <span ng-click="changeState(entity,'Rejected')">Rejected</span>
                                                    </li>
                                                </ul>
                                            </div>
                                        </td>

                                        <td operations edit="off"></td>

                                    </tr>
                                </table>
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

