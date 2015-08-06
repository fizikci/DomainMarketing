<div class="page-header">
    <h1>Coupon
        <small><i class="icon-double-angle-right"></i> edit</small>
    </h1>
</div>

<form id="form" class="form-horizontal" role="form" autocomplete="off">

<input type="text" ng-model="entity.Id" name="Id" style="display:none"/>

<div class="row">
    <div class="col-sm-9">
		
        <input-text label="Coupon Name" model="entity.Name"></input-text>
        <input-select label="Type" model="entity.CouponType" options="i.Id as i.Name for i in EnumCouponTypes"></input-select>
        <input-number label="Value" model="entity.Value"></input-number>
        <input-select label="Currency (if money)" model="entity.Currency" options="i for i in ['TL','$','€']"></input-select>
        <input-date label="Valid from" model="entity.ValidFrom"></input-date>
        <input-date label="Valid to" model="entity.ValidTo"></input-date>
        <input-number label="Number to generate" model="entity.GenerateNumber"></input-number>
        <input-check label="MultiUsage" model="entity.MultiUsage"></input-check>
        <input-check label="Valid For 1 Year" model="entity.ValidFor1Year"></input-check>

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
