<div class="page-header">
    <h1 class="blue">
        <i class="icon-tag"></i>
        Reseller
    <small>
        <i class="icon-double-angle-right"></i>
        View reseller details
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
                                <span class="white">{{entity.ResellerName}}</span>
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
                <span class="orange">Type: </span>{{entity.ResellerTypeName}}<br/>
                <a href="#/View/Member/{{entity.Id}}">Go to member info.</a>
            </small>

        </div>

        <div class="hr hr16 dotted"></div>
    </div>

    <div class="col-xs-12 col-sm-9">

        <div class="profile-user-info profile-user-info-striped">
            <div class="profile-info-row">
                <div class="profile-info-name" style="width: 190px;">Setup / Kayıt Ücreti </div>

                <div class="profile-info-value" style="margin-left: 200px;">
                    {{entity.SetupRegisterFee/100 | currency}}
                </div>
            </div>
            <div class="profile-info-row">
                <div class="profile-info-name" style="width: 190px;">Ön ödemeli Kredi Şartı </div>

                <div class="profile-info-value" style="margin-left: 200px;">
                    {{entity.PrePaidCreditAmount/100 | currency}}
                </div>
            </div>
            <div class="profile-info-row">
                <div class="profile-info-name" style="width: 190px;">Kabul edilen min. Ek kredi </div>

                <div class="profile-info-value" style="margin-left: 200px;">
                    {{entity.MinAdditionalCreditAmount/100 | currency}}
                </div>
            </div>
            <div class="profile-info-row">
                <div class="profile-info-name" style="width: 190px;">Ek süre için gereken krediler </div>

                <div class="profile-info-value" style="margin-left: 200px;">
                    +0 gün {{entity.AdditionalDays0StartFee/100 | currency}} - {{entity.AdditionalDays0EndFee/100 | currency}}
                </div>
            </div>
            <div class="profile-info-row">
                <div class="profile-info-name" style="width: 190px;"></div>

                <div class="profile-info-value" style="margin-left: 200px;">
                    +30 gün {{entity.AdditionalDays30StartFee/100 | currency}} - {{entity.AdditionalDays30EndFee/100 | currency}}
                </div>
            </div>
            <div class="profile-info-row">
                <div class="profile-info-name" style="width: 190px;"></div>

                <div class="profile-info-value" style="margin-left: 200px;">
                    +90 gün {{entity.AdditionalDays90StartFee/100 | currency}} - {{entity.AdditionalDays90EndFee/100 | currency}}
                </div>
            </div>
            <div class="profile-info-row">
                <div class="profile-info-name" style="width: 190px;">Partner Rozerti </div>

                <div class="profile-info-value" style="margin-left: 200px;">
                    {{entity.ResellerTypeName}}
                </div>
            </div>
            <div class="profile-info-row">
                <div class="profile-info-name" style="width: 190px;">MDF katılım hakkı </div>

                <div class="profile-info-value" style="margin-left: 200px;">
                    {{entity.CanJoinMdf?'VAR':'YOK'}}
                </div>
            </div>
            <div class="profile-info-row">
                <div class="profile-info-name" style="width: 190px;">Partner Ağında Listelenme </div>

                <div class="profile-info-value" style="margin-left: 200px;">
                    {{entity.ListInPartnerNetwork}}
                </div>
            </div>
            <div class="profile-info-row">
                <div class="profile-info-name" style="width: 190px;">API kullanım hakkı </div>

                <div class="profile-info-value" style="margin-left: 200px;">
                    VAR
                </div>
            </div>
            <div class="profile-info-row">
                <div class="profile-info-name" style="width: 190px;">Marketing Material Desteği </div>

                <div class="profile-info-value" style="margin-left: 200px;">
                    VAR
                </div>
            </div>
            <div class="profile-info-row">
                <div class="profile-info-name" style="width: 190px;">Destek Grubu </div>

                <div class="profile-info-value" style="margin-left: 200px;">
                    {{entity.SupportGroup}}
                </div>
            </div>
            <div class="profile-info-row">
                <div class="profile-info-name" style="width: 190px;">İndirim Oranı </div>

                <div class="profile-info-value" style="margin-left: 200px;">
                    {{entity.RebateRate | number}} %
                </div>
            </div>
            <div class="profile-info-row">
                <div class="profile-info-name" style="width: 190px;">Nakit Geri Ödeme </div>

                <div class="profile-info-value" style="margin-left: 200px;">
                    {{entity.CashRefund?'VAR':'YOK'}}
                </div>
            </div>
        </div>
        <div class="widget-box transparent" id="recent-box">
            <div class="widget-header">
                <div class="widget-toolbar no-border">
                    <ul class="nav nav-tabs" id="recent-tab">
                        <li class="{{tab=='mdfs' ? 'active':''}}">
                            <a ng-click="tab='mdfs'"><i class="icon-accept red"></i>MDFs</a>
                        </li>
                    </ul>
                </div>
            </div>

            <div class="widget-body">
                <div class="widget-main padding-4">
                    <div class="tab-content padding-8 overflow-visible">
                        <div class="tab-pane{{tab=='mdfs' ? 'active':''}}">
                            <div ng-controller="ViewDetailListController" ng-init="entityName='MdfReseller'; where='ResellerId = '">
                                <page-size ng-show="count/pageSize>1"></page-size>
                                <pagination ng-show="count/pageSize>1"></pagination>
                                <table class="table table-striped table-bordered table-hover dataTable" aria-describedby="table-storage_info">
                                    <tr>
                                        <th>#</th>
                                        <th column-header="Mdf" field="MdfName"></th>
                                        <th></th>
                                    </tr>
                                    <tr ng-repeat="entity in list" ng-class="{deleted:entity.IsDeleted}">
                                        <td indexer></td>
                                        <td link-to-parent="Mdf">{{entity.MdfName}}</td>
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

