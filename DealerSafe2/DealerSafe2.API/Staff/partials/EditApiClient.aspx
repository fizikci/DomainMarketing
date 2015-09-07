    <div class="page-header">
        <h1>API Client
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
		
        <input-select label="API" model="entity.ApiId" options="i.Id as i.Name for i in Apis"></input-select>
    
        <input-select label="Client" model="entity.ClientId" options="i.Id as i.Name for i in Clients"></input-select>

        <input-text label="Client API Key" model="entity.ClientApiKey"></input-text>

		<input-text label="Client URL" model="entity.Url"></input-text>
		
	</div>
    <div class="col-sm-3">
    <!--PUT HERE A PICTURE OR SOMETHING ELSE-->
	</div>
</div>
    
<div class="row">
	
	<div class="col-xs-12 col-sm-6">
		<h3 class="header smaller lighter blue">Mail Settings</h3>
		
		<input-text label="From" model="entity.MailFrom"></input-text>
		<input-text label="Host" model="entity.MailHost"></input-text>
		<input-number label="Port" model="entity.MailPort"></input-number>
		<input-text label="Username" model="entity.MailUserName"></input-text>
		<input-text label="Password" model="entity.MailPassword"></input-text>

		
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
