<div class="page-header">
    <h1 class="blue">
        <i class="icon-tag"></i>
        Coupon
    <small>
        <i class="icon-double-angle-right"></i>
        View coupon details
    </small>
    </h1>
</div>

<div id="user-profile-1" class="user-profile row">
    <div class="col-xs-12 col-sm-3 center">
        <div>
            <span class="profile-picture">
                <i class="icon-tag" style="font-size:50px"></i>
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
                <span class="orange">Type: </span>{{entity.ProductType}}<br>
            </small>

        </div>

        <div class="hr hr16 dotted"></div>
    </div>

    <div class="col-xs-12 col-sm-9">

        <div class="profile-user-info profile-user-info-striped">
            <div class="profile-info-row">
                <div class="profile-info-name">Type </div>

                <div class="profile-info-value">
                    {{entity.CouponType}}
                </div>
            </div>

            <div class="profile-info-row">
                <div class="profile-info-name">Value </div>

                <div class="profile-info-value">
                    <b ng-show="entity.CouponType=='Percentage'">%</b> {{entity.Value}} <b ng-show="entity.CouponType=='Money'">{{entity.Currency}}</b>
                </div>
            </div>
        </div>



        <div class="widget-box transparent" id="recent-box">
            <div class="widget-header">
                <div class="widget-toolbar no-border">
                    <ul class="nav nav-tabs" id="recent-tab">
                        <li class="{{tab=='items' ? 'active':''}}">
                            <a ng-click="tab='items'"><i class="icon-tag blue"></i>Coupon Items</a>
                        </li>
                        <li class="{{tab=='products' ? 'active':''}}">
                            <a ng-click="tab='products'"><i class="icon-gamepad red"></i>Products</a>
                        </li>
                    </ul>
                </div>
            </div>

            <div class="widget-body">
                <div class="widget-main padding-4">
                    <div class="tab-content padding-8 overflow-visible">
                            
                        <div class="tab-pane{{tab=='items' ? 'active':''}}">
                            <div ng-controller="ViewDetailListController" ng-init="entityName='CouponItem'; where='CouponId = '">
                                <page-size ng-show="count/pageSize>1"></page-size>
                                <pagination ng-show="count/pageSize>1"></pagination>
                                <table class="table table-striped table-bordered table-hover dataTable" aria-describedby="table-storage_info">
                                    <tr ng-repeat="entity in list" ng-class="{deleted:entity.IsDeleted}">
                                        <td>{{entity.Id}}</td>
                                    </tr>
                                </table>
                            </div>
                        </div>

                        <div class="tab-pane{{tab=='products' ? 'active':''}}">
                            <div ng-controller="ViewDetailListController" ng-init="entityName='CouponProduct'; where='CouponId = '">
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
                                        <input-select noEmptyOption="1" horizontal="yes" label="Product" model="selectedProduct" options="i.Id as i.Name for i in Products"></input-select>
                                        <input type="button" value="Add" ng-click="addProduct()" />
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

