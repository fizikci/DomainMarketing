<div class="page-header">
    <h1 class="blue">
        <i class="icon-gamepad"></i>
        Supplier
    <small>
        <i class="icon-double-angle-right"></i>
        a product supplier
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
                            <a href="#/Edit/Supplier/{{entity.Id}}">
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
                <div class="profile-info-name">API </div>

                <div class="profile-info-value">
                    {{entity.ApiName}}
                </div>
            </div>

            <div class="profile-info-row">
                <div class="profile-info-name">Url </div>

                <div class="profile-info-value">
                    {{entity.Url}}
                </div>
            </div>

            <div class="profile-info-row">
                <div class="profile-info-name">Login </div>

                <div class="profile-info-value">
                    {{entity.Username}} - {{entity.Password}}
                </div>
            </div>
        </div>



        <div class="widget-box transparent" id="recent-box" ng-init="tab='props'">
            <div class="widget-header">
                <div class="widget-toolbar no-border">
                    <ul class="nav nav-tabs" id="recent-tab">
                        <li class="{{tab=='reg' ? 'active':''}}" ng-show="entity.ApiId=='DealerSafe'">
                            <a ng-click="tab='reg'"><i class="icon-map-marker blue"></i>Registry Details</a>
                        </li>
                        <li class="{{tab=='domainDefs' ? 'active':''}}" ng-show="entity.ApiId=='DealerSafe'">
                            <a ng-click="tab='domainDefs'"><i class="icon-map-marker blue"></i>Domain Defaults</a>
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
                            
                        <div ng-if="entity.ApiId=='DealerSafe'" class="tab-pane{{tab=='reg' ? 'active':''}}" ng-controller="EditRegistryController">


                            <div class="row">
                                <input type="text" ng-model="entity.Id" name="Id" style="display:none"/>
                                    <input-select label="Registry Backend" model="entity.RegistryBackendId" options="i.Id as i.Name for i in RegistryBackends"></input-select>
		                            <input-check label="Follow Poll Messages" model="entity.FollowPollMessages"></input-check>
                                    <div style="clear:both"></div>
                                    <fieldset class="col-sm-6">
                                        <legend>EPP</legend>
                                        <input-text label="Server" model="entity.EppServerUri"></input-text>
                                        <input-text label="Port" model="entity.EppServerPort"></input-text>
                                        <input-text label="Username" model="entity.EppUsername"></input-text>
                                        <input-text label="Password" model="entity.EppPassword"></input-text>
                                        <input-check label="Secure Conn." model="entity.EppSecureConnection"></input-check>
                                        <div class="col-sm-offset-3 col-sm-9">
                                            <input-text ng-show="entity.EppSecureConnection" label="Path" model="entity.EppCertPath"></input-text>
                                            <input-text ng-show="entity.EppSecureConnection" label="Password" model="entity.EppCertPassword"></input-text>
                                        </div>
                                    </fieldset>
                                    <fieldset class="col-sm-6">
                                        <legend>OTE</legend>
                                        <input-text label="Server" model="entity.OteServerUri"></input-text>
                                        <input-text label="Port" model="entity.OteServerPort"></input-text>
                                        <input-text label="Username" model="entity.OteUsername"></input-text>
                                        <input-text label="Password" model="entity.OtePassword"></input-text>
                                        <input-check label="Secure Conn." model="entity.OteSecureConnection"></input-check>
                                        <div class="col-sm-offset-3 col-sm-9">
                                            <input-text ng-show="entity.OteSecureConnection" label="Path" model="entity.OteCertPath"></input-text>
                                            <input-text ng-show="entity.OteSecureConnection" label="Password" model="entity.OteCertPassword"></input-text>
                                        </div>
                                    </fieldset>		

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
                            
                        <div ng-if="entity.ApiId=='DealerSafe'" class="tab-pane{{tab=='domainDefs' ? 'active':''}}" ng-controller="EditDomainDefaultsForRegistryController">


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

                    </div>

                </div>
            </div>
            <!-- /widget-main -->
        </div>
        <!-- /widget-body -->
    </div>
</div>

