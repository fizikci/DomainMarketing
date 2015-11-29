<div class="page-header">
    <h1 class="blue">
        <i class="icon-tag"></i>
        JOB
    <small>
        <i class="icon-double-angle-right"></i>
        Job Detail
    </small>
    </h1>
</div>

<div id="user-profile-1" class="user-profile row"> 
    <div class="col-xs-12 col-sm-12"> 
        <h4>Job Info</h4>
        <div class="profile-user-info profile-user-info-striped">
            <info-row label="Create Date">{{entity.InsertDate | date:'dd-MM-yyyy HH:mm'}}</info-row>
            <info-row label="Command">{{entity.Command}}</info-row>
            <info-row label="Display Name">{{entity.Name}}</info-row>
            <info-row label="Related with">{{entity.RelatedEntityName}} ({{entity.RelatedEntityId}}) <a ng-show="entity.RelatedEntityName=='OrderItem'" href="#/View/Order/{{orderItem.OrderId}}">Go to the order</a></info-row>
            <info-row label="Last Executed by">{{entity.Executer}} ({{entity.ExecuterId || '-'}})</info-row>
            <div style="clear:both"></div>
        </div>
        <h4>Job Statistics</h4>
        <div class="profile-user-info profile-user-info-striped">
            <info-row label="Start Date">{{entity.StartDate | date:'dd-MM-yyyy HH:mm'}}</info-row>
            <info-row label="State"><span class="badge badge-{{jobStateClass}}">{{entity.State}}</span></info-row>
            <info-row label="Try Count">{{entity.TryCount}}</info-row>
            <info-row label="Last Process Time">{{entity.ProcessTime}} ms</info-row>
            <div style="clear:both"></div>
        </div>
        <div ng-repeat="jd in jobDatas" class="col-sm-offset-1 col-sm-11">
            <h6 class="red" style="font-weight:bold">Try {{$index+1}} at {{jd.InsertDate | date:'dd-MM-yyyy HH:mm:ss'}}</h6>
            <div class="profile-user-info profile-user-info-striped">
                <info-row label="Request Url">{{jd.RequestUrl}}</info-row><div style="clear:both"></div>
                <div class="profile-info-row row-sm-12"><div class="profile-info-name">Request </div><div class="profile-info-value"><pre>{{jd.Request}}</pre></div></div>
                <div class="profile-info-row row-sm-12"><div class="profile-info-name">Response </div><div class="profile-info-value"><pre>{{jd.Response}}</pre></div></div>
                <div style="clear:both"></div>
            </div>
        </div>
        <!-- /widget-body -->
    </div>
</div>

<style>
    h4, h6 {
        margin-top:30px;
        margin-left:20px;
    }
</style>