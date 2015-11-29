    <div class="page-header">
        <h1>Supplier
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
		
        <input-id label="ID" model="entity.Id"></input-id>
        <input-select label="Api" model="entity.ApiId" options="i.Id as i.Name for i in Apis"></input-select>
        <input-text label="Name" model="entity.Name"></input-text>
        <input-text label="Url" model="entity.Url"></input-text>
        <input-text label="Username" model="entity.Username"></input-text>
        <input-text label="Password" model="entity.Password"></input-text>
        <input-number label="Order No" model="entity.OrderNo"></input-number>
        <input-select label="Use Custom Life Cycle" model="entity.LifeCycleId" options="i.Id as i.Name for i in LifeCycles"></input-select>
        <input-select label="Use Property Set" model="entity.PropertySetId" options="i.Id as i.Name for i in PropertySets"></input-select>
		
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
