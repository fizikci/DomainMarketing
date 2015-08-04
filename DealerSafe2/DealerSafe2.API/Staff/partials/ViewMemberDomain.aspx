<div class="page-header">
    <h1 class="blue">
        <i class="icon-gamepad"></i>
        Member Domain
    <small>
        <i class="icon-double-angle-right"></i>
        View member domain details
    </small>
    </h1>
</div>

<div id="user-profile-1" class="user-profile row">
    <div class="col-xs-12 col-sm-3 center">
        <div>
            <span class="profile-picture">
                <i class="icon-gamepad" style="font-size: 50px"></i>
            </span>

            <div class="space-4"></div>

            <div class="width-80 label label-info label-xlg arrowed-in arrowed-in-right">
                <div class="inline position-relative">
                    <a class="user-title-label dropdown-toggle" data-toggle="dropdown">
                        <i class="icon-circle light-green"></i>
                        &nbsp;
                                <span class="white">{{entity.DomainName}}</span>
                    </a>

                    <ul class="align-left dropdown-menu dropdown-caret dropdown-lighter">
                        <li class="dropdown-header">Process </li>

                        <li>
                            <a href="#/Edit/MemberDomain/{{entity.Id}}">
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

            <small class="block"></small>

        </div>

        <div class="hr hr16 dotted"></div>
    </div>

    <div class="col-xs-12 col-sm-9">

        <div class="profile-user-info profile-user-info-striped">


                <info-row label="Domain Name" col-sm="6">{{entity.DomainName}}</info-row>
                <info-row label="Domain IDN" col-sm="6">{{entity.DomainIDN}}</info-row>
                <info-row label="ROID" col-sm="6">{{entity.ROID}}</info-row>
                <info-row label="Update Date" col-sm="6">{{entity.UpdateDate}}</info-row>
                <info-row label="Renewal Mode" col-sm="6">{{entity.RenewalMode}}</info-row>
                <info-row label="Product Name" col-sm="6">{{entity.ProductName}}</info-row>
                <info-row label="Transfer Mode" col-sm="6">{{entity.TransferMode}}</info-row>
                <info-row label="Registry Status" col-sm="6">{{entity.RegistryStatus}}</info-row>
                <info-row label="RGP Status" col-sm="6">{{entity.RGPStatus}}</info-row>
                <info-row label="Sponsor Id" col-sm="6">{{entity.SponsorId}}</info-row>
                <info-row label="Creator Id" col-sm="6">{{entity.CreatorId}}</info-row>
                <info-row label="Name Servers" col-sm="6">{{entity.NameServers}}</info-row>
                <info-row label="Host Names" col-sm="6">{{entity.HostNames}}</info-row>
                <info-row label="Zone" col-sm="6">{{entity.ZoneId}}</info-row>
                <info-row label="Owner Domain" col-sm="6">{{entity.OwnerDomainContactId}}</info-row>
                <info-row label="Admin Domain" col-sm="6">{{entity.AdminDomainContactId}}</info-row>
                <info-row label="Tech Domain" col-sm="6">{{entity.TechDomainContactId}}</info-row>
                <info-row label="Billing Domain" col-sm="6">{{entity.BillingDomainContactId}}</info-row>
                <info-row label="P.Protection" col-sm="6">{{entity.PrivacyProtection}}</info-row>
                <info-row label="Auth Info" col-sm="6">{{entity.AuthInfo}}</info-row>
                <info-row label="O.Status" col-sm="6">{{entity.OperationalStatus}}</info-row>
                <info-row label="Price Mode" col-sm="6">{{entity.PriceMode}}</info-row>
                <info-row label="Transfer Date" col-sm="6">{{entity.TransferDate}}</info-row>
                <info-row label="Order Item Id" col-sm="6">{{entity.OrderItemId}}</info-row>
                <info-row label="Registry Date" col-sm="6">{{entity.StartDate}}</info-row>
                <info-row label="Expiry Date" col-sm="6">{{entity.EndDate}}</info-row>
                <div style="clear: both"></div>


        </div>



        <div class="widget-box transparent" id="recent-box">
            <div class="widget-header">
                <div class="widget-toolbar no-border">
                    <ul class="nav nav-tabs" id="recent-tab">

                        <li class="{{tab=='contact' ? 'active':''}}">
                            <a ng-click="tab='contact'"><i class="icon-envelope-alt red"></i>Domain Contact</a>
                        </li>
                    </ul>
                </div>
            </div>

            <div class="widget-body">
                <div class="widget-main padding-4">
                    <div class="tab-content padding-8 overflow-visible">


                        <div class="tab-pane{{tab=='contact' ? 'active':''}}">

                            <table ng-if="!currAddr" id="tblAddress" class="table table-striped table-bordered table-hover dataTable" aria-describedby="table-storage_info">
                                <tr>

                                    <th>Type</th>
                                    <th>Operation</th>
                                </tr>
                                <tr ng-repeat="a in addresses" ng-class="{deleted:a.IsDeleted}">
                                    <td>{{a.Type}}</td>

                                    <td>
                                        <a class="dtBtn green" ng-click="editAddress(a)" target="_blank"><i class="icon-pencil bigger-130"></i></a>
                                        <a class="dtBtn red" ng-click="deleteAddress(a)"><i class="icon-trash bigger-130"></i></a>
                                    </td>
                                </tr>
                            </table>
                            <div ng-if="!currAddr" class="clearfix form-actions">
                                <div class="text-right">
                                    <button class="btn btn-xs btn-primary" type="button" ng-click="newAddress()">
                                        <i class="icon-plus bigger-110"></i>
                                        Add New
                                    </button>
                                </div>
                            </div>

                            <div ng-if="currAddr">
                                <form class="form-horizontal" role="form" autocomplete="off">
                                    <input type="text" ng-model="currAddr.Id" name="Id" style="display: none" />
                                    <input type="text" ng-model="currAddr.MemberDomainId" name="MemberDomainId" style="display: none" />

                                    <div class="row">

                                        <div class="form-group">
                                            <label for="Type" class="col-sm-3 control-label no-padding-right">Type </label>
                                            <div class="col-sm-9">
                                                <select ng-model="currAddr.Type" ng-options="n.Id as n.Name for n in EnumContactTypes" class="col-sm-6">
                                                </select>
                                                <input type="text" style="display: none" ng-model="currAddr.Type" name="Type" />
                                            </div>
                                        </div>

                                        <div class="space-4"></div>

                                        <div class="form-group">
                                            <label for="Organization" class="col-sm-3 control-label no-padding-right">Organization </label>
                                            <div class="col-sm-9">

                                                <input type="text" ng-model="currAddr.Organization" name="Organization" placeholder="" class="col-sm-6" />

                                            </div>
                                        </div>

                                        <div class="space-4"></div>

                                        <div class="form-group">
                                            <label for="Email" class="col-sm-3 control-label no-padding-right">Email</label>
                                            <div class="col-sm-9">

                                                <input type="text" ng-model="currAddr.Email" name="Email" placeholder="" class="col-sm-6" />

                                            </div>
                                        </div>

                                        <div class="space-4"></div>

                                        <div class="form-group">
                                            <label for="Country" class="col-sm-3 control-label no-padding-right">Country </label>
                                            <div class="col-sm-9">

                                                <select ng-model="currAddr.Country" ng-options="c.Id as c.Name for c in countries" ng-change="getCities()" class="col-sm-9">
                                                    <option value=""></option>
                                                </select>
                                                <input type="text" style="display: none" name="Country" ng-model="currAddr.Country" />
                                            </div>
                                        </div>

                                        <div class="space-4"></div>

                                        <div class="form-group">
                                            <label for="State" class="col-sm-3 control-label no-padding-right">State </label>
                                            <div class="col-sm-9">

                                                <select ng-model="currAddr.State" name="State" class="col-sm-9">
                                                    <option value="0"></option>
                                                    <option>Value</option>
                                                </select>

                                            </div>
                                        </div>

                                        <div class="space-4"></div>

                                        <div class="form-group">
                                            <label for="City" class="col-sm-3 control-label no-padding-right">City </label>
                                            <div class="col-sm-9">

                                                <select ng-model="currAddr.City" ng-options="c.Id as c.Name for c in cities" class="col-sm-9">
                                                    <option value=""></option>
                                                </select>
                                                <input type="text" style="display: none" name="City" ng-model="currAddr.City" />
                                            </div>
                                        </div>

                                        <div class="space-4"></div>

                                        <div class="form-group">
                                            <label for="Zip" class="col-sm-3 control-label no-padding-right">Zip </label>
                                            <div class="col-sm-9">

                                                <input type="text" ng-model="currAddr.Zip" name="Zip" placeholder="" class="col-sm-6" />

                                            </div>
                                        </div>

                                        <div class="space-4"></div>

                                        <div class="form-group">
                                            <label for="Address" class="col-sm-3 control-label no-padding-right">Address </label>
                                            <div class="col-sm-9">

                                                <input type="text" ng-model="currAddr.Address" name="Address" placeholder="" class="col-sm-6" />

                                            </div>
                                        </div>


                                        <div class="space-4"></div>

                                        <div class="form-group">
                                            <label for="Fax" class="col-sm-3 control-label no-padding-right">Fax </label>
                                            <div class="col-sm-9">

                                                <input type="text" ng-model="currAddr.Fax" name="Fax" placeholder="" class="col-sm-6" />

                                            </div>
                                        </div>

                                        <div class="space-4"></div>

                                        <div class="form-group">
                                            <label for="Phone" class="col-sm-3 control-label no-padding-right">Phone </label>
                                            <div class="col-sm-9">

                                                <input type="text" ng-model="currAddr.Phone" name="Phone" placeholder="" class="col-sm-6" />

                                            </div>
                                        </div>

                                        <div class="space-4"></div>

                                        <div class="form-group">
                                            <label for="Town" class="col-sm-3 control-label no-padding-right">Town </label>
                                            <div class="col-sm-9">

                                                <input type="text" ng-model="currAddr.Town" name="Town" placeholder="" class="col-sm-6" />

                                            </div>
                                        </div>


                                    </div>


                                    <div class="clearfix form-actions">
                                        <div class="text-right">
                                            <button class="btn btn-xs btn-primary" type="button" ng-click="saveAddress()">
                                                <i class="icon-ok bigger-110"></i>
                                                Save
                                            </button>
                                            &nbsp; 
                                        <button class="btn btn-xs btn-info" type="button" ng-click="cancelEditAddress()">
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

