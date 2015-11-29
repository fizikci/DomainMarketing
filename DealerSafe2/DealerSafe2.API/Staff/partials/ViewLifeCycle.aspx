<div class="page-header">
    <h1 class="blue">
        <i class="icon-tag"></i>
        Life Cycle
        <small>
            <i class="icon-double-angle-right"></i>
            generic life cycle definition
        </small>
    </h1>
</div>

<div id="user-profile-1" class="user-profile row relative">

    <div class="col-xs-12 col-sm-12">
        
        <h1>
            {{entity.Name}}
            <div class="pull-right">
                <button class="btn btn-primary btn-sm" ng-click="addPhase()">Add Phase</button> &nbsp; 
                <button class="btn btn-primary btn-sm" ng-click="addJob()">Add Job</button>
            </div>
        </h1>

        <div class="life-cycle">
            <div class="phase" ng-repeat="phase in phases" style="width:{{phase.ui.width / totalWidth*100}}%; background-color:{{phase.ui.color}}">
                <div class="title"><b>{{phase.Name}} <i class="icon-pencil green" ng-click="editPhase(phase)"></i> <i class="icon-remove red" ng-click="deletePhase(phase)"></i></b></div>
                <p>{{phase.Days}} days</p>
            </div>

            <div class="job {{job.Executer}}" ng-repeat="job in jobs" style="left:{{job.ui.left / totalWidth*100}}%;width:{{job.ui.width / totalWidth*100}}%;" title="{{job.Description}}">
                <span style=" top:{{job.ui.top}}px">
                    <i class="icon-gear green" ng-show="job.Executer=='Machine'"></i>
                    <i class="icon-user red" ng-show="job.Executer=='Member'"></i>
                    <i class="icon-wrench orange" ng-show="job.Executer=='Staff'"></i>
                    {{job.RunAtDay}}:  <i class="icon-pencil green op" ng-click="editJob(job)"></i> <i class="icon-remove red op" ng-click="deleteJob(job)"></i>
                    <b>{{job.Command}}</b>
                </span>
            </div>
        </div>


    </div>

    <ul class="pull-right phaseDef hide">
        <li ng-repeat="(key, value) in colors"><span style="background:{{value}}"></span> {{key}}</li>
    </ul>
    <ul class="pull-right phaseDef">
        <li><span style="background:lightgray"></span> None</li>
        <li><span style="background:rgb(199, 252, 199)"></span> Active</li>
        <li><span style="background:rgb(124, 240, 255)"></span> WaitingForRenewal</li>
        <li><span style="background:rgb(255, 209, 124)"></span> WaitingForRestore</li>
        <li><span style="background:rgb(255, 185, 197)"></span> Deleted</li>
        <li><span style="background:rgb(255, 254, 174)"></span> BackupAvailable</li>
    </ul>

    <div style="clear:both"></div>

    <div class="dialog edit-phase" ng-show="currPhase">
        <input-text name="Name" label="Phase Name" model="currPhase.Name"></input-text>
        <input-number name="Days" label="Days" model="currPhase.Days"></input-number>
        <input-select label="Phase Type" model="currPhase.PhaseType" options="i.Id as i.Name for i in EnumLifeCyclePhases"></input-select>
        <input-text name="Description" label="Description" model="currJob.Description"></input-text>
        <input-number name="OrderNo" label="Order" model="currPhase.OrderNo"></input-number>
        <br />
        <button class="btn btn-primary" ng-click="savePhase()">Save</button>
        <button class="btn btn-default" ng-click="cancelEditPhase()">Cancel</button>
    </div>

    <div class="dialog edit-job" ng-show="currJob">
        <input-select label="Command" model="currJob.Command" options="i.Id as i.Name for i in EnumJobCommands"></input-select>
        <input-select label="Executer" model="currJob.Executer" options="i.Id as i.Name for i in EnumJobExecuters"></input-select>
        <input-number name="RunAtDay" label="Run at day" model="currJob.RunAtDay"></input-number>
        <input-number name="ValidForDays" label="Valid for days" model="currJob.ValidForDays"></input-number>
        <input-text name="Description" label="Description" model="currJob.Description"></input-text>
        <hr />
        <div ng-if="currJob.Command=='CCSendMessage'">
            <input-select label="Message Template" model="currJob.RelatedEntityId" options="i.Id as i.Name for i in MessageTemplates"></input-select>
        </div>
        <br />
        <button class="btn btn-primary" ng-click="saveJob()">Save</button>
        <button class="btn btn-default" ng-click="cancelEditJob()">Cancel</button>
    </div>

</div>

<style>
    .life-cycle {
        position:relative;
        border-left: 1px solid black;
        border-top: 1px solid black;
        border-bottom: 1px solid black;
    }
    .phase {
      display: inline-block;
      overflow: hidden;
      vertical-align: top;
      text-align:center;
      height: 360px;
      border-right: 1px solid black;
    }
    .phase .title {
      border-bottom: 1px solid black;
    }
    .phase p {
      border-bottom: 1px solid rgba(0, 0, 0, 0.22);
    }
    .job {
      position: absolute;
      top: 20px;
      border-left: 1px dashed rgba(0, 0, 0, 0.22);
    }
    .job.Member span {
      border: 1px solid red;
      background-color: rgb(255,235,235);
      width: 100%;
    }
    .job.Staff span {
      border: 1px solid orange;
      background-color: rgb(250, 232, 199);
    }
    .job.Machine span {
      border: 1px solid green;
      background-color: rgb(235,255,235);
    }
    .job span {
      padding: 0px 5px;
      cursor:pointer;
      border-radius: 0 15px 15px 0;
      text-align: left;
      position: absolute;
    }
    .job span i.op {
        display:none;
    }
    .job span:hover i.op {
        display:inline;
    }


    ul.phaseDef {
        width: 170px;
        margin: 12px;
        padding: 13px;
        clear: both;
    }

    ul.phaseDef > li {
        margin: 0px;
        padding: 0px;
        list-style: none;
        font-size: smaller;
    }

    ul.phaseDef > li > span {
        display: inline-block;
        width: 14px;
        height: 14px;
        vertical-align: text-bottom;
    }
</style>



