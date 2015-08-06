<div class="page-header">
    <h1 class="blue">
        <i class="icon-tag"></i>
        Ticket
    <small>
        <i class="icon-double-angle-right"></i>
        Ticket details
    </small>
    </h1>
</div>

<div id="user-profile-1" class="user-profile row">

    <div class="col-xs-12 col-sm-12">
       
        <div class="position-relative pull-right">
            Change status of this ticket to: 
            <a class="user-title-label dropdown-toggle" data-toggle="dropdown">
                <span ng-class="{badge:1, 'badge-primary': entity.State=='Processing', 'badge-success': entity.State=='Done', 'badge-danger': entity.State=='Failed', 'badge-warning': entity.State=='Canceled'}">{{entity.State}}</span>
                <img src="/Assets/images/icons/down.png" />
            </a>

            <ul class="align-left dropdown-menu dropdown-caret dropdown-lighter">
                <li>&nbsp;
                    <i class="icon-circle blue"></i>
                    &nbsp;
                    <span ng-click="changeState(entity,'Processing')">Processing</span>
                </li>
                <li>&nbsp;
                    <i class="icon-circle red"></i>
                    &nbsp;
                    <span ng-click="changeState(entity,'Failed')">Failed</span>
                </li>
                <li>&nbsp;
                    <i class="icon-circle green"></i>
                    &nbsp;
                    <span ng-click="changeState(entity,'Done')">Done</span>
                </li>
                <li>&nbsp;
                    <i class="icon-circle orange"></i>
                    &nbsp;
                    <span ng-click="changeState(entity,'Canceled')">Canceled</span>
                </li>
            </ul>
        </div>
        <div style="clear:both"></div>
        <br />
        <br />
        <div class="profile-user-info profile-user-info-striped">
            <div class="profile-info-row">
                <div class="profile-info-name">Email </div>
                <div class="profile-info-value">{{entity.Email}}</div>
            </div>
            <div class="profile-info-row">
                <div class="profile-info-name">Name </div>
                <div class="profile-info-value">{{entity.MemberName}}</div>
            </div>
            <div class="profile-info-row">
                <div class="profile-info-name">Date </div>
                <div class="profile-info-value">{{entity.InsertDate | date:'dd-MM-yyyy HH:mm'}}</div>
            </div>
            <div class="profile-info-row">
                <div class="profile-info-name">Subject </div>
                <div class="profile-info-value">{{entity.Subject}}</div>
            </div>
            <div class="profile-info-row">
                <div class="profile-info-name">To Department </div>
                <div class="profile-info-value">{{entity.Department}}</div>
            </div>
            <div class="profile-info-row">
                <div class="profile-info-name">Message </div>
                <div class="profile-info-value">{{entity.Message}}</div>
            </div>

        </div>
        <div class="widget-box transparent" id="recent-box" ng-init="tab='Tickets'">
            <div class="widget-header">
                <div class="widget-toolbar no-border">
                    <ul class="nav nav-tabs" id="recent-tab">
                        <li class="{{tab=='Tickets' ? 'active':''}}">
                            <a ng-click="tab='Tickets'"><i class="icon-map-marker blue"></i>Replies</a>
                        </li>
                    </ul>
                </div>
            </div>

            <div class="widget-body">
                <div class="widget-main padding-4">
                    <div class="tab-content padding-8 overflow-visible">
                        <div id="tickets-tab" class="tab-pane{{tab=='Tickets' ? 'active':''}}">
                            <div ng-controller="ViewDetailListController" ng-init="entityName='CrmActivityMessage'; where='CrmActivityId = '">
                                <table id="tblTickets" class="table table-striped table-bordered table-hover dataTable" aria-describedby="table-storage_info">
                                    <tr>
                                        <th>Date</th>
                                        <th>Member</th>
                                        <th>Message</th>
                                    </tr>
                                    <tr ng-repeat="t in tickets" ng-class="{deleted:a.IsDeleted}">
                                        <td>{{t.InsertDate | date:'yyyy.MM.dd HH:mm'}}</td>
                                        <td link-to-parent="Member">{{t.MemberName}}</td>
                                        <td>{{t.Message}}</td>
                                    </tr>
                                </table>
                                <div class="clearfix form-actions">
                                    <textarea id="txtreply"  placeholder="Enter your reply here"   class="col-sm-10" style="height: 80px; width: 100%;"></textarea>
                                </div>
                                <div style="float: right;">
                                    <button ng-click="addReply()">Send</button>
                                    <button>Cancel</button>
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

