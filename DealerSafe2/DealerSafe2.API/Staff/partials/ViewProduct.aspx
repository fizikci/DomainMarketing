<div class="page-header">
    <h1 class="blue">
        <i class="icon-gamepad"></i>
        Product
    <small>
        <i class="icon-double-angle-right"></i>
        View product details
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
                            <a href="#/Edit/Product/{{entity.Id}}">
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
                <div class="profile-info-name">Type </div>

                <div class="profile-info-value">
                    {{entity.ProductTypeId}}
                </div>
            </div>

            <div class="profile-info-row">
                <div class="profile-info-name">Supplier </div>

                <div class="profile-info-value">
                    {{entity.SupplierId}}
                </div>
            </div>
        </div>



        <div class="widget-box transparent" id="recent-box">
            <div class="widget-header">
                <div class="widget-toolbar no-border">
                    <ul class="nav nav-tabs" id="recent-tab">
                        <li class="{{tab=='domainDefs' ? 'active':''}}" ng-show="entity.ProductTypeId=='DOMAIN'">
                            <a ng-click="tab='domainDefs'"><i class="icon-map-marker blue"></i>Domain Defaults</a>
                        </li>
                        <li class="{{tab=='props' ? 'active':''}}">
                            <a ng-click="tab='props'"><i class="icon-map-marker blue"></i>Properties</a>
                        </li>
                        <li class="{{tab=='prices' ? 'active':''}}">
                            <a ng-click="tab='prices'"><i class="icon-envelope-alt red"></i>Prices</a>
                        </li>
                    </ul>
                </div>
            </div>

            <div class="widget-body">
                <div class="widget-main padding-4">
                    <div class="tab-content padding-8 overflow-visible">

                        <div ng-if="entity.ProductTypeId=='DOMAIN'" class="tab-pane{{tab=='domainDefs' ? 'active':''}}" ng-controller="EditDomainDefaultsForZoneController">


                            <div class="row">
                                <input type="text" ng-model="entity.Id" name="Id" style="display:none"/>
                                <input-select label="Renewal Mode" model="entity.RenewalMode" options="i.Id as i.Name for i in RenewalModes"></input-select>
                                <input-select label="Transfer Mode" model="entity.TransferMode" options="i.Id as i.Name for i in TransferModes"></input-select>
                                <input-text label="Owner Contact Id" model="entity.OwnerDomainContactId"></input-text>
                                <input-text label="Admin Contact Id" model="entity.AdminDomainContactId"></input-text>
                                <input-text label="Tech Contact Id" model="entity.TechDomainContactId"></input-text>
                                <input-text label="Billing Contact Id" model="entity.BillingDomainContactId"></input-text>
                                <input-select label="Privacy Protection" model="entity.PrivacyProtection" options="i.Id as i.Name for i in PrivacyProtectionOptions"></input-select>
                                <input-text label="Name Servers" model="entity.NameServers"></input-text>
                            </div>

                            <div class="clearfix form-actions">
	                            <div class="text-right">
		                            <button class="btn btn-xs btn-primary" type="button" ng-click="save()">
			                            <i class="icon-ok bigger-110"></i>
			                            Save
		                            </button>
	                            </div>
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

                        <div class="tab-pane{{tab=='prices' ? 'active':''}}">
                            <table ng-if="!currPrice" class="table table-striped table-bordered table-hover dataTable" aria-describedby="table-storage_info">
                                <tr>
                                    <th>Id</th>
                                    <th>Amount-Unit</th>
                                    <th>Price-Currency</th>
                                    <th></th>
                                </tr>

                                <tr ng-repeat="p in prices | orderBy:'Amount'" ng-class="{deleted:p.IsDeleted}">
                                    <td>{{p.Id}}</td>
                                    <td>{{p.Amount+' '+p.Unit}} of {{p.ProductPriceType}}</td>
                                    <td>{{p.Price/100 | currency:p.Currency}} <i ng-if="p.Recommended" class="icon-ok green bigger-110"></i></td>
                                    <td>
                                        <a class="dtBtn green" ng-click="editPrice(p)" target="_blank"><i class="icon-pencil bigger-130"></i></a>
                                        <a class="dtBtn red" ng-click="deletePrice(p)"><i class="icon-trash bigger-130"></i></a>
                                    </td>
                                </tr>
                            </table>
                            <div ng-if="!currPrice" class="clearfix form-actions">
                                <div class="text-right">
                                    <button class="btn btn-xs btn-primary" type="button" ng-click="newPrice()">
                                        <i class="icon-plus bigger-110"></i>
                                        Add New
                                    </button>
                                </div>
                            </div>
                            <div ng-if="currPrice">
                                <form class="form-horizontal" role="form" autocomplete="off">
                                <input type="text" ng-model="currPrice.Id" name="Id" style="display:none"/>
                                <input type="text" ng-model="currPrice.ProductId" name="ProductId" style="display:none"/>

                                    <div class="row">
    
                                        <div class="space-4"></div>			
		                                <div class="form-group">
                                            <label for="Unit" class="col-sm-3 control-label no-padding-right"> Price Type </label>
                                            <div class="col-sm-9">
				
                                                <select ng-model="currPrice.ProductPriceType" ng-options="i.Id as i.Name for i in priceTypes" class="col-sm-9">
                                                </select>	
                                            </div>
                                        </div>


                                        <div class="space-4"></div>			
		                                <div class="form-group">
                                            <label for="Price" class="col-sm-3 control-label no-padding-right"> Price </label>
                                            <div class="col-sm-9">
				
                                            <input ng-model="currPrice.Price" name="Price" class="input-mini bkspinner" type="text" value="0"/>
		
                                            </div>
                                        </div>
    
                                        <div class="space-4"></div>			
		                                <div class="form-group">
                                            <label for="PurchasePrice" class="col-sm-3 control-label no-padding-right"> PurchasePrice </label>
                                            <div class="col-sm-9">
				
                                            <input ng-model="currPrice.PurchasePrice" name="PurchasePrice" class="input-mini bkspinner" type="text" value="0"/>
		
                                            </div>
                                        </div>
    
                                        <div class="space-4"></div>			
		                                <div class="form-group">
                                            <label for="DiscountPrice" class="col-sm-3 control-label no-padding-right"> DiscountPrice </label>
                                            <div class="col-sm-9">
				
                                            <input ng-model="currPrice.DiscountPrice" name="DiscountPrice" class="input-mini bkspinner" type="text" value="0"/>
		
                                            </div>
                                        </div>
    
                                        <div class="space-4"></div>			
		                                <div class="form-group">
                                            <label for="Amount" class="col-sm-3 control-label no-padding-right"> Amount </label>
                                            <div class="col-sm-9">
				
                                            <input ng-model="currPrice.Amount" name="Amount" class="input-mini bkspinner" type="text" value="0"/>
		
                                            </div>
                                        </div>
    
                                        <div class="space-4"></div>			
		                                <div class="form-group">
                                            <label for="Unit" class="col-sm-3 control-label no-padding-right"> Unit </label>
                                            <div class="col-sm-9">
				
                                                <select ng-model="currPrice.Unit" ng-options="i for i in ['months','years','pieces']" class="col-sm-9">
                                                </select>
                                                <input type="text" style="display:none" ng-model="currPrice.Unit" name="Unit" />		
                                            </div>
                                        </div>
    
                                        <div class="space-4"></div>			
		                                <div class="form-group">
                                            <label for="Currency" class="col-sm-3 control-label no-padding-right"> Currency </label>
                                            <div class="col-sm-9">
                                                <select ng-model="currPrice.Currency" ng-options="i for i in ['TL','$','€']" class="col-sm-9">
                                                </select>
                                                <input type="text" style="display:none" ng-model="currPrice.Currency" name="Currency" />		
                                            </div>
                                        </div>

                                        <div class="space-4"></div>			
		
                                        <div class="form-group">
                                            <label for="Recommended" class="col-sm-3 control-label no-padding-right"> Recommended </label>
                                            <div class="col-sm-9">
                                                <label class="col-sm-4">
                                                    <input ng-model="currPrice.Recommended" name="Recommended" class="ace ace-switch ace-switch-5" value="1" type="checkbox"/>
                                                    <span class="lbl"></span>
                                                </label>
                                            </div>
                                        </div>

                                    </div>
                                <div class="clearfix form-actions">
                                    <div class="text-right">
                                        <button class="btn btn-xs btn-primary" type="button" ng-click="savePrice()">
                                            <i class="icon-ok bigger-110"></i>
                                            Save
                                        </button>
                                        &nbsp; 
                                        <button class="btn btn-xs btn-info" type="button" ng-click="cancelEditPrice()">
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

