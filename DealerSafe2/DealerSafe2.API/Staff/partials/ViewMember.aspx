<div class="page-header">
    <h1 class="blue">
        <i class="icon-user"></i>
        Member
    <small>
        <i class="icon-double-angle-right"></i>
        View member details
    </small>
    </h1>
</div>

<div id="user-profile-1" class="user-profile row">
    <div class="col-xs-12 col-sm-3 center">
        <div>
            <span class="profile-picture">
                <img id="avatar" class="img-responsive" alt="Avatar" ng-src="{{m.Avatar || '/Assets/avatars/emp.png'}}">
            </span>

            <div class="space-4"></div>

            <div class="width-80 label label-info label-xlg arrowed-in arrowed-in-right">
                <div class="inline position-relative">
                    <a class="user-title-label dropdown-toggle" data-toggle="dropdown">
                        <i class="icon-circle light-green"></i>
                        &nbsp;
                                <span class="white">{{m.FullName}}</span>
                    </a>

                    <ul class="align-left dropdown-menu dropdown-caret dropdown-lighter">
                        <li class="dropdown-header">Process </li>

                        <li>
                            <a href="#/Edit/Member/{{m.Id}}">
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
                <span class="orange">Type: </span>
                <span ng-show="m.MemberType!='Reseller'">{{m.MemberType}}</span>
                <span ng-show="m.MemberType=='Reseller'"><a href="#/View/Reseller/{{m.Id}}">{{m.MemberType}}</a></span>
                <br />
                <span class="orange">State: </span>{{m.State}}
            </small>

        </div>

        <div class="hr hr16 dotted"></div>
    </div>

    <div class="col-xs-12 col-sm-9">

        <div class="profile-user-info profile-user-info-striped">
            <div class="profile-info-row">
                <div class="profile-info-name">Email </div>

                <div class="profile-info-value">
                    <a href="mailto:{{m.Email}}">{{m.Email}}</a>
                </div>
            </div>

            <div class="profile-info-row">
                <div class="profile-info-name">Birth Date </div>

                <div class="profile-info-value">
                    {{m.DateOfBirth | date}}
                </div>
            </div>

            <div class="profile-info-row">
                <div class="profile-info-name">Gender </div>

                <div class="profile-info-value">
                    {{m.Gender=='F' ? 'Female' : (m.Gender=='M' ? 'Male' : '-')}}
                </div>
            </div>

            <div class="profile-info-row">
                <div class="profile-info-name">Company </div>

                <div class="profile-info-value">
                    {{m.CompanyInfo}}
                </div>
            </div>

            <div class="profile-info-row">
                <div class="profile-info-name">Phone </div>

                <div class="profile-info-value">
                    <span>{{m.PhoneNumber}}</span>
                    <span ng-if="m.FaxNumber" class="orange">Fax:</span> {{m.FaxNumber}}
                    <span ng-if="m.GsmPhoneNumber" class="orange">Mobile:</span> {{m.GsmPhoneNumber}}
                </div>
            </div>

            <div class="profile-info-row">
                <div class="profile-info-name">Languages </div>

                <div class="profile-info-value">
                    &nbsp;{{m.LanguageId}}
                </div>
            </div>
        </div>



        <div class="widget-box transparent" id="recent-box">
            <div class="widget-header">
                <div class="widget-toolbar no-border">
                    <ul class="nav nav-tabs" id="recent-tab">
                        <li class="{{tab=='Tickets' ? 'active':''}}">
                            <a ng-click="tab='Tickets'"><i class="icon-map-marker blue"></i>Tickets</a>
                        </li>
                        <li class="{{tab=='Addresses' ? 'active':''}}">
                            <a ng-click="tab='Addresses'"><i class="icon-map-marker blue"></i>Addresses</a>
                        </li>
                        <li class="{{tab=='NewsLetters' ? 'active':''}}">
                            <a ng-click="tab='NewsLetters'"><i class="icon-envelope-alt red"></i>NewsLetters</a>
                        </li>
                        <li class="{{tab=='Roles' ? 'active':''}}">
                            <a ng-click="tab='Roles'"><i class="icon-tag orange"></i>Roles</a>
                        </li>
                        <!--li class="{{tab=='Bank Accounts' ? 'active':''}}">
                            <a ng-click="tab='Bank Accounts'"><i class="icon-money green"></i>Bank Accounts</a>
                        </li-->
                        <li class="{{tab=='Basket' ? 'active':''}}">
                            <a ng-click="tab='Basket'"><i class="icon-shopping-cart green"></i>Basket</a>
                        </li>
                    </ul>
                </div>
            </div>

            <div class="widget-body">
                <div class="widget-main padding-4">
                    <div class="tab-content padding-8 overflow-visible">
                        
                        <div id="tickets-tab" class="tab-pane{{tab=='Tickets' ? 'active':''}}">
                            <table id="tblTickets" class="table table-striped table-bordered table-hover dataTable" aria-describedby="table-storage_info">
                                <tr>
                                    <th>Date</th>
                                    <th>Subject</th>
                                    <th>Department</th>
                                    <th></th>
                                </tr>
                                <tr ng-repeat="t in tickets" ng-class="{deleted:a.IsDeleted}">
                                    <td>{{t.InsertDate | date}}</td>
                                    <td><a href="#/View/CrmActivity/{{t.Id}}">{{t.Subject}}</a></td>
                                    <td>{{t.Department}}</td>
                                    <td>
                                        <a class="dtBtn red" ng-click="deleteTickets(t)"><i class="icon-trash bigger-130"></i></a>
                                    </td>
                                </tr>
                            </table>
                        </div>

                        <div id="address-tab" class="tab-pane{{tab=='Addresses' ? 'active':''}}">
                            <table ng-if="!currAddr" id="tblAddress" class="table table-striped table-bordered table-hover dataTable" aria-describedby="table-storage_info">
                                <tr>
                                    <th>Address</th>
                                    <th>Type</th>
                                    <th>Operation</th>
                                </tr>
                                <tr ng-repeat="a in addresses" ng-class="{deleted:a.IsDeleted}">
                                    <td>{{a.InvoiceTitle}}</td>
                                    <td>{{a.AddressType}}</td>
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
                                    <input type="text" ng-model="currAddr.MemberId" name="MemberId" style="display: none" />

                                    <div class="row">

                                        <div class="form-group">
                                            <label for="AddressType" class="col-sm-3 control-label no-padding-right">AddressType </label>
                                            <div class="col-sm-9">
                                                <select ng-model="currAddr.AddressType" ng-options="n.Id as n.Name for n in addressTypes" class="col-sm-6">
                                                </select>
                                                <input type="text" style="display: none" ng-model="currAddr.AddressType" name="AddressType" />
                                            </div>
                                        </div>

                                        <div class="space-4"></div>

                                        <div class="form-group">
                                            <label for="Title" class="col-sm-3 control-label no-padding-right">Title </label>
                                            <div class="col-sm-9">

                                                <input type="text" ng-model="currAddr.Title" name="Title" placeholder="" class="col-sm-6" />

                                            </div>
                                        </div>

                                        <div class="space-4"></div>

                                        <div class="form-group">
                                            <label for="InvoiceTitle" class="col-sm-3 control-label no-padding-right">InvoiceTitle </label>
                                            <div class="col-sm-9">

                                                <input type="text" ng-model="currAddr.InvoiceTitle" name="InvoiceTitle" placeholder="" class="col-sm-6" />

                                            </div>
                                        </div>

                                        <div class="space-4"></div>

                                        <div class="form-group">
                                            <label for="CountryId" class="col-sm-3 control-label no-padding-right">CountryId </label>
                                            <div class="col-sm-9">

                                                <select ng-model="currAddr.CountryId" ng-options="c.Id as c.Name for c in countries" ng-change="getCities()" class="col-sm-9">
                                                    <option value=""></option>
                                                </select>
                                                <input type="text" style="display: none" name="CountryId" ng-model="currAddr.CountryId" />
                                            </div>
                                        </div>

                                        <div class="space-4"></div>

                                        <div class="form-group">
                                            <label for="StateId" class="col-sm-3 control-label no-padding-right">StateId </label>
                                            <div class="col-sm-9">

                                                <select ng-model="currAddr.StateId" name="StateId" class="col-sm-9">
                                                    <option value="0"></option>
                                                    <option>Value</option>
                                                </select>

                                            </div>
                                        </div>

                                        <div class="space-4"></div>

                                        <div class="form-group">
                                            <label for="CityId" class="col-sm-3 control-label no-padding-right">CityId </label>
                                            <div class="col-sm-9">

                                                <select ng-model="currAddr.CityId" ng-options="c.Id as c.Name for c in cities" class="col-sm-9">
                                                    <option value=""></option>
                                                </select>
                                                <input type="text" style="display: none" name="CityId" ng-model="currAddr.CityId" />
                                            </div>
                                        </div>

                                        <div class="space-4"></div>

                                        <div class="form-group">
                                            <label for="ZipCode" class="col-sm-3 control-label no-padding-right">ZipCode </label>
                                            <div class="col-sm-9">

                                                <input type="text" ng-model="currAddr.ZipCode" name="ZipCode" placeholder="" class="col-sm-6" />

                                            </div>
                                        </div>

                                        <div class="space-4"></div>

                                        <div class="form-group">
                                            <label for="AddressText" class="col-sm-3 control-label no-padding-right">AddressText </label>
                                            <div class="col-sm-9">

                                                <input type="text" ng-model="currAddr.AddressText" name="AddressText" placeholder="" class="col-sm-6" />

                                            </div>
                                        </div>

                                        <div class="space-4"></div>

                                        <div class="form-group">
                                            <label for="CityName" class="col-sm-3 control-label no-padding-right">CityName </label>
                                            <div class="col-sm-9">

                                                <input type="text" ng-model="currAddr.CityName" name="CityName" placeholder="" class="col-sm-6" />

                                            </div>
                                        </div>

                                        <div class="space-4"></div>

                                        <div class="form-group">
                                            <label for="TaxOffice" class="col-sm-3 control-label no-padding-right">TaxOffice </label>
                                            <div class="col-sm-9">

                                                <input type="text" ng-model="currAddr.TaxOffice" name="TaxOffice" placeholder="" class="col-sm-6" />

                                            </div>
                                        </div>

                                        <div class="space-4"></div>

                                        <div class="form-group">
                                            <label for="TaxNumber" class="col-sm-3 control-label no-padding-right">TaxNumber </label>
                                            <div class="col-sm-9">

                                                <input type="text" ng-model="currAddr.TaxNumber" name="TaxNumber" placeholder="" class="col-sm-6" />

                                            </div>
                                        </div>

                                        <div class="space-4"></div>

                                        <div class="form-group">
                                            <label for="PhoneNumber" class="col-sm-3 control-label no-padding-right">PhoneNumber </label>
                                            <div class="col-sm-9">

                                                <input type="text" ng-model="currAddr.PhoneNumber" name="PhoneNumber" placeholder="" class="col-sm-6" />

                                            </div>
                                        </div>

                                        <div class="space-4"></div>


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

                        <div id="newsletter-tab" class="tab-pane{{tab=='NewsLetters' ? 'active':''}}">
                            <table id="tblNewsletter" class="table table-striped table-bordered table-hover dataTable" aria-describedby="table-storage_info">
                                <tr>
                                    <th>Newsletter</th>
                                    <th>Operation</th>
                                </tr>
                                <tr ng-repeat="n in newsletters" ng-class="{deleted:n.IsDeleted}">
                                    <td>{{n.NewsletterDefinitionName}}</td>
                                    <td>
                                        <a class="dtBtn red" ng-click="deleteNewsletter(n)"><i class="icon-trash bigger-130"></i></a>
                                    </td>
                                </tr>
                            </table>
                            <div class="form-actions">
                                <div class="input-group">
                                    <select class="form-control" ng-model="selectedNewsletterOption" ng-options="n.Name for n in newsletterOptions">
                                        <option value="0"></option>
                                    </select>
                                    <span class="input-group-btn">
                                        <button class="btn btn-sm btn-info no-radius" type="button" ng-click="addNewsletter()">
                                            <i class="icon-share"></i>
                                            Add
                                        </button>
                                    </span>
                                </div>
                            </div>
                        </div>

                        <div id="role-tab" class="tab-pane{{tab=='Roles' ? 'active':''}}">
                            <table id="tblRole" class="table table-striped table-bordered table-hover dataTable" aria-describedby="table-storage_info">
                                <tr>
                                    <th>Role</th>
                                    <th>Operation</th>
                                </tr>

                                <tr ng-repeat="r in roles" ng-class="{deleted:r.IsDeleted}">
                                    <td>{{r.Name}}</td>
                                    <td>
                                        <a class="dtBtn red" ng-click="deleteRole(r)"><i class="icon-trash bigger-130"></i></a>
                                    </td>
                                </tr>
                            </table>
                            <div class="form-actions">
                                <div class="input-group">
                                    <select class="form-control" ng-model="selectedRoleOption" ng-options="r.Name for r in roleOptions">
                                        <option value="0"></option>
                                    </select>
                                    <span class="input-group-btn">
                                        <button class="btn btn-sm btn-info no-radius" type="button" ng-click="addRole()">
                                            <i class="icon-share"></i>
                                            Add
                                        </button>
                                    </span>
                                </div>
                            </div>
                        </div>

                        <!--div id="bankaccount-tab" class="tab-pane{{tab=='Bank Accounts' ? 'active':''}}">
                            <table ng-if="!currBank" id="tblBankAccount" class="table table-striped table-bordered table-hover dataTable" aria-describedby="table-storage_info">
                                <tr>
                                    <th>Bank Account</th>
                                    <th>Operation</th>
                                </tr>

                                <tr ng-repeat="b in banks" ng-class="{deleted:b.IsDeleted}">
                                    <td>{{b.BankName}}</td>
                                    <td>
                                        <a class="dtBtn green" ng-click="editBank(b)" target="_blank"><i class="icon-pencil bigger-130"></i></a>
                                        <a class="dtBtn red" ng-click="deleteBank(b)"><i class="icon-trash bigger-130"></i></a>
                                    </td>
                                </tr>
                            </table>
                            <div ng-if="!currBank" class="clearfix form-actions">
                                <div class="text-right">
                                    <button class="btn btn-xs btn-primary" type="button" ng-click="newBank()">
                                        <i class="icon-plus bigger-110"></i>
                                        Add New
                                    </button>
                                </div>
                            </div>
                            <div ng-if="currBank">
                                <form class="form-horizontal" role="form" autocomplete="off">
                                    <input type="text" ng-model="currBank.Id" name="Id" style="display: none" />
                                    <input type="text" ng-model="currBank.MemberId" name="MemberId" style="display: none" />

                                    <div class="row">
                                        <div class="form-group">
                                            <label for="BankName" class="col-sm-3 control-label no-padding-right">Bank Name </label>
                                            <div class="col-sm-9">

                                                <input type="text" ng-model="currBank.BankName" name="BankName" placeholder="" class="col-sm-6" />

                                            </div>
                                        </div>

                                        <div class="space-4"></div>

                                        <div class="form-group">
                                            <label for="BranchName" class="col-sm-3 control-label no-padding-right">Branch Name </label>
                                            <div class="col-sm-9">

                                                <input type="text" ng-model="currBank.BranchName" name="BranchName" placeholder="" class="col-sm-6" />

                                            </div>
                                        </div>

                                        <div class="space-4"></div>

                                        <div class="form-group">
                                            <label for="BrunchNumber" class="col-sm-3 control-label no-padding-right">Brunch Number </label>
                                            <div class="col-sm-9">

                                                <input type="text" ng-model="currBank.BrunchNumber" name="BrunchNumber" placeholder="" class="col-sm-6" />

                                            </div>
                                        </div>

                                        <div class="space-4"></div>

                                        <div class="form-group">
                                            <label for="HolderName" class="col-sm-3 control-label no-padding-right">Holder Name </label>
                                            <div class="col-sm-9">

                                                <input type="text" ng-model="currBank.HolderName" name="HolderName" placeholder="" class="col-sm-6" />

                                            </div>
                                        </div>

                                        <div class="space-4"></div>

                                        <div class="form-group">
                                            <label for="HolderIdentity" class="col-sm-3 control-label no-padding-right">Holder Identity </label>
                                            <div class="col-sm-9">

                                                <input type="text" ng-model="currBank.HolderIdentity" name="HolderIdentity" placeholder="" class="col-sm-6" />

                                            </div>
                                        </div>

                                        <div class="space-4"></div>

                                        <div class="form-group">
                                            <label for="AccountTitle" class="col-sm-3 control-label no-padding-right">Account Title </label>
                                            <div class="col-sm-9">

                                                <input type="text" ng-model="currBank.AccountTitle" name="AccountTitle" placeholder="" class="col-sm-6" />

                                            </div>
                                        </div>


                                        <div class="space-4"></div>

                                        <div class="form-group">
                                            <label for="AcountNumber" class="col-sm-3 control-label no-padding-right">Acount Number </label>
                                            <div class="col-sm-9">

                                                <input type="text" ng-model="currBank.AcountNumber" name="AcountNumber" placeholder="" class="col-sm-6" />

                                            </div>
                                        </div>

                                        <div class="space-4"></div>

                                        <div class="form-group">
                                            <label for="IBAN" class="col-sm-3 control-label no-padding-right">IBAN </label>
                                            <div class="col-sm-9">

                                                <input type="text" ng-model="currBank.IBAN" name="IBAN" placeholder="" class="col-sm-6" />

                                            </div>
                                        </div>

                                    </div>
                                    <div class="clearfix form-actions">
                                        <div class="text-right">
                                            <button class="btn btn-xs btn-primary" type="button" ng-click="saveBank()">
                                                <i class="icon-ok bigger-110"></i>
                                                Save
                                            </button>
                                            &nbsp; 
                                        <button class="btn btn-xs btn-info" type="button" ng-click="cancelEditBank()">
                                            <i class="icon-undo bigger-110"></i>
                                            Cancel
                                        </button>
                                        </div>
                                    </div>
                                </form>
                            </div>
                        </div-->

                        <div id="order-tab" class="tab-pane{{tab=='Basket' ? 'active':''}}">
                            <table id="tblNewsletter" class="table table-striped table-bordered table-hover dataTable" aria-describedby="table-storage_info">
                                <tr>
                                    <th>Amount</th>
                                    <th>Product</th>
                                    <th>Price</th>
                                    <th></th>
                                </tr>
                                <tr ng-repeat="item in basket.Items" ng-class="{deleted:n.IsDeleted}">
                                    <td>{{item.Amount}} {{item.Unit}} </td>
                                    <td>{{item.ProductId}}</td>
                                    <td>{{item.Price/100}}</td>
                                    <td>
                                        <a class="dtBtn red" ng-click="removeFromBasket(item)"><i class="icon-trash bigger-130"></i></a>
                                    </td>
                                </tr>
                            </table>
                            <div class="text-right" ng-if="basket">
                                Total amount : <span class="green">{{basket.TotalPrice/100 | currency:basket.Currency+' '}}</span>
                            </div>
                            <div class="text-right" ng-if="basket">
                                Coupon discount : <span class="red">{{basket.Discount/100 | currency:basket.Currency+' '}}</span>
                            </div>
                            <div class="form-actions">
                                <div class="input-group">
                                    <select class="col-sm-6" ng-model="selectedBasketProduct" ng-options="n.Id as n.Name for n in products" ng-change="getPrices()"></select>
                                    <select class="col-sm-6" ng-model="selectedBasketPrice" ng-options="pr.Id as pr.Amount +' '+ pr.Unit +' ('+pr.Currency+pr.Price/100+')' for pr in prices | orderBy:'Amount'"></select>
                                    <span class="input-group-btn">
                                        <button class="btn btn-sm btn-info no-radius" type="button" ng-click="addToBasket()">
                                            <i class="icon-share"></i>
                                            Add
                                        </button>
                                    </span>
                                </div>
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

