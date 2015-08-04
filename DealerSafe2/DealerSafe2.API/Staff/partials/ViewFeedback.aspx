<div class="page-header">
    <h1 class="blue">
        <i class="icon-tag"></i>
        Feedback
    <small>
        <i class="icon-double-angle-right"></i>
        from site visitor
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
        <div style="clear: both"></div>
        <br />
        <br />
        <div class="profile-user-info profile-user-info-striped">
            <div class="profile-info-row">
                <div class="profile-info-name">Email </div>
                <div class="profile-info-value">{{entity.Email}}</div>
            </div>
            <div class="profile-info-row">
                <div class="profile-info-name">Name </div>
                <div class="profile-info-value">{{entity.Name}}</div>
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
            <div ng-if="entity.ReplyMessage" class="profile-info-row">
                <div class="profile-info-name">Reply Message </div>
                <div class="profile-info-value">{{entity.ReplyMessage}}</div>
            </div>
            <div ng-if="!entity.ReplyMessage"  class="profile-info-row" style="height: 92px;">
                <div class="profile-info-name">Reply </div>
                <div class="profile-info-value">
                    <textarea placeholder="Enter your reply here" id="txtReplyMessage" class="col-sm-10" style="height: 80px; width: 100%;"></textarea>
                </div>
            </div>
        </div>
        <br/>
            <button style="float: right;" class="btn btn-primary col-sm-2" ng-click="sendFeedbackReply(entity)">Send</button>
        <!-- /widget-body -->
    </div>
    
</div>

