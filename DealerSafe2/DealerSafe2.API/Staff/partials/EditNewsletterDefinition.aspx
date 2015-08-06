    <div class="page-header">
        <h1>Newsletter
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
            <label for="ApiId" class="col-sm-3 control-label no-padding-right"> Api </label>
            <div class="col-sm-9">
				
                <select ng-model="entity.ApiId" ng-options="i.Id as i.Name for i in Apis" class="col-sm-6">
                    <option value=""></option>
                </select>
                <input type="text" style="display:none" ng-model="entity.ApiId" name="ApiId" />
			
            </div>
        </div>
    
        <div class="space-4"></div>			
		
        <div class="form-group">
            <label for="Name" class="col-sm-3 control-label no-padding-right"> Title </label>
            <div class="col-sm-9">
				
				<input type="text" ng-model="entity.Name" name="Name" placeholder="" class="col-sm-6" />
		
            </div>
        </div>
    
        <div class="space-4"></div>			
		
        <div class="form-group">
            <label for="Content" class="col-sm-3 control-label no-padding-right"> Content </label>
            <div class="col-sm-9">
                <textarea ng-model="entity.Content" name="Content" class="col-sm-12" rows="10"></textarea>
            </div>
        </div>

        <div class="space-4"></div>			
		
        <div class="form-group">
            <label for="OrderNo" class="col-sm-3 control-label no-padding-right"> Order No </label>
            <div class="col-sm-9">
				
				<input type="text" ng-model="entity.OrderNo" name="OrderNo" placeholder="" class="col-sm-1" />
		
            </div>
        </div>
		
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
