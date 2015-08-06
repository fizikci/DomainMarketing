<div class="page-header">
    <h1>Message Template
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
            <input-id label="ID" model="entity.Id"></input-id>
            <input-select label="Message Group" model="entity.CCMessageGroupId" options="i.Id as i.Name for i in MsgGroups"></input-select>
            <input-text label="Name" model="entity.Name"></input-text>
            <input-text label="Subject" model="entity.Subject"></input-text>
            <input-textarea label="Message" name="Message" model="entity.Message" html-edit="true"></input-textarea>
       
            <input-textarea label="Command" model="entity.SqlCommand" style="margin: 0px; height: 192px; font-family: monospace; font-size: medium;"></input-textarea>

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

