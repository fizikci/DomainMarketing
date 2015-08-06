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
        <div class="profile-user-info profile-user-info-striped">
            <info-row label="Name">{{entity.Name}}</info-row>
            <info-row label="Command">{{entity.Command}}</info-row>
            <info-row label="State">{{entity.State}}</info-row>
            <info-row ng-if="entity.RequestUrl" label="RequestUrl">{{entity.RequestUrl}}</info-row>
            <div ng-if="entity.Request" class="profile-info-row">
                <div class="profile-info-name">Request </div>

                <div class="profile-info-value">
                    <pre>
                    {{entity.Request}}</pre>
                </div>
            </div>
            <div ng-if="entity.Response" class="profile-info-row">
                <div class="profile-info-name">Response </div>

                <div class="profile-info-value">
                    <pre>
                    {{entity.Response}}</pre>
                </div>
            </div>
            <info-row label="TryCount">{{entity.TryCount}}</info-row>
            <info-row label="ProcessTime">{{entity.ProcessTime}}</info-row>
            <info-row label="Date">{{entity.InsertDate | date:'dd-MM-yyyy HH:mm'}}</info-row>
        </div>
        <!-- /widget-body -->
    </div>
</div>

