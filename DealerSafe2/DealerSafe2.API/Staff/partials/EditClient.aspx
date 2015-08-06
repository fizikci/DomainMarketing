    <div class="page-header">
        <h1>Client
            <small>
                <i class="icon-double-angle-right"></i>
                edit
            </small>
        </h1>
    </div>

<form id="form" class="form-horizontal" role="form" autocomplete="off">

<input type="text" ng-model="entity.Id" name="Id" style="display:none"/>

<div class="row">
    <div class="col-sm-9">
		
        <div class="form-group">
            <label for="Name" class="col-sm-3 control-label no-padding-right"> Name </label>
            <div class="col-sm-9">
				
                <input-id label="ID" model="entity.Id"></input-id>
                <input ng-model="entity.Name" type="text" name="Name" class="col-sm-8"/>
            </div>
        </div>
        
         <input-text label="Connection Strings" model="entity.ConnectionStrings"></input-text>
		
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
