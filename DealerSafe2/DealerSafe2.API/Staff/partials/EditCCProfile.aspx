<div class="page-header">
    <h1>Profile
            <small>
                <i class="icon-double-angle-right"></i>
                edit
            </small>
    </h1>
</div>

<form id="form" class="form-horizontal" role="form" autocomplete="off">

    <input type="text" ng-model="entity.Id" name="Id" style="display: none" />

    <div class="row">
        <div class="col-sm-9">

            <input-select label="Client" model="entity.ClientId" options="i.Id as i.Name for i in Clients"></input-select>
            <input-text label="Name" model="entity.Name"></input-text>
            <input-select label="Profile Type" model="entity.ProfileType" options="i.Id as i.Name for i in EnumProfileTypes"></input-select>
            <input-select ng-show="entity.ProfileType=='Email'" label="E-Mail Socket" model="entity.CCEmailSocketId" options="i.Id as i.Name for i in EmailSockets"></input-select>
            <input-select ng-show="entity.ProfileType=='Sms'" label="Sms Socket" model="entity.CCSmsSocketId" options="i.Id as i.Name for i in SmsSockets"></input-select>
            <input-text ng-show="entity.ProfileType=='Email'" label="Send Name" model="entity.SendName"></input-text>
            <input-text ng-show="entity.ProfileType=='Email'" label="Send Mail" model="entity.SendMail"></input-text>
            <input-text ng-show="entity.ProfileType=='Email'" label="Reply Mail" model="entity.ReplyMail"></input-text>
            <input-text label="Note" model="entity.Note"></input-text>
            <input-select label="Priority" model="entity.Priority" options="i.Id as i.Name for i in EnumPrioritys"></input-select>

        </div>
        <div class="col-sm-3">
            <!--PUT HERE A PICTURE OR SOMETHING ELSE-->
        </div>
    </div>

    <div class="clearfix form-actions">
        <div class="text-right">
            <button class="btn btn-xs btn-primary" type="button" ng-click="save()">
                <i class="icon-ok bigger-110"></i>
                Save
            </button>
            &nbsp; 
		<button class="btn btn-xs btn-info" type="button" onclick="history.go(-1)">
            <i class="icon-undo bigger-110"></i>
            Cancel
        </button>
        </div>
    </div>

</form>

