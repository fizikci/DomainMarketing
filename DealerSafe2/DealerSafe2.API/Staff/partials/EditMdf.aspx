<div class="page-header">
    <h1>MDF
        <small><i class="icon-double-angle-right"></i> edit</small>
    </h1>
</div>

<form id="form" class="form-horizontal" role="form" autocomplete="off">

<input type="text" ng-model="entity.Id" name="Id" style="display:none"/>

<div class="row">
    <div class="col-sm-9">
		
        <input-id label="ID" model="entity.Id"></input-id>
        <input-text label="Name" model="entity.Name"></input-text>
        <input-textarea label="Description" model="entity.Description"></input-textarea>
        <input-textarea label="Text" model="entity.MdfText"></input-textarea>
        <input-select label="Country" model="entity.CountryId" options="i.Id as i.Name for i in ListCountry"></input-select>
        <input-select label="Reseller Type" model="entity.ResellerTypeId" options="i.Id as i.Name for i in ListResellerType"></input-select>
        <input-date label="Valid from" model="entity.StartDate"></input-date>
        <input-date label="Valid to" model="entity.EndDate"></input-date>
        <input-date label="Announce from" model="entity.AnnounceStartDate"></input-date>
        <input-date label="Announce to" model="entity.AnnounceEndDate"></input-date>
        <input-number label="Rebate Rate" model="entity.RebateRate"></input-number>
        <input-number label="Rebate Amount" model="entity.RebateAmount"></input-number>
        <input-number label="Limit Bottom" model="entity.LimitBottom"></input-number>
        <input-number label="Limit Top" model="entity.LimitTop"></input-number>

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
