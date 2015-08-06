    <div class="page-header">
        <h1>Member
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
		
        <input-text label="First Name" model="entity.FirstName" name="FirstName"></input-text>
        <input-text label="Last Name" model="entity.LastName" name="LastName"></input-text>
        <input-select label="Gender" model="entity.Gender" name="Gender" options="i as i for i in ['M','F']"></input-select>
        <input-date label="BirthDate" model="entity.DateOfBirth" name="DateOfBirth"></input-date>
        <input-text label="Birth Place" model="entity.PlaceOfBirth" name="PlaceOfBirth"></input-text>
        <input-text label="Nationality" model="entity.Nationality" name="Nationality"></input-text>
        <input-text label="Identity No" model="entity.IdentityNo" name="IdentityNo"></input-text>
		
	</div>
    <div class="col-sm-3">
    <!--PUT HERE A PICTURE OR SOMETHING ELSE-->
	</div>
</div>

<div class="row">
	
	<div class="col-xs-12 col-sm-6">
		<h3 class="header smaller lighter blue">Contact Info</h3>
		
	        <input-text label="Email" model="entity.Email" name="Email"></input-text>
            <input-text label="Alternative Email" model="entity.AlternativeEmail" name="AlternativeEmail"></input-text>
	        <input-text label="Twitter Id" model="entity.TwitterId" name="TwitterId"></input-text>
	        <input-text label="Fax Number" model="entity.FaxNumber" name="FaxNumber"></input-text>
	        <input-select label="Default Address" model="entity.MemberAddressId" name="MemberAddressId" options="i.Id as i.Name for i in Addresses"></input-select>
	        <input-number label="Timezone" model="entity.TimeZone" name="TimeZone"></input-number>
	        <input-text label="Phone" model="entity.PhoneNumber" name="PhoneNumber"></input-text>
	        <input-text label="Locale" model="entity.Locale" name="Locale"></input-text>
	        <input-text label="Facebook Id" model="entity.FacebookId" name="FacebookId"></input-text>
	        <input-text label="Mobile Phone" model="entity.GsmPhoneNumber" name="GsmPhoneNumber"></input-text>
	        <input-text label="Web Site" model="entity.WebSite" name="WebSite"></input-text>
	        <input-text label="GEO Loc" model="entity.GeoLocation" name="GeoLocation"></input-text>
		
	</div>
	
	<div class="col-xs-12 col-sm-6">
		<h3 class="header smaller lighter blue">Account Info</h3>
		
	        <input-text label="Avatar" model="entity.Avatar" name="Avatar"></input-text>
	        <input-text label="Username" model="entity.UserName" name="UserName"></input-text>
	        <input-select label="Language" model="entity.LanguageId" name="LanguageId" options="i.Id as i.Name for i in Languages"></input-select>
	        <input-text label="Member Risk Level" model="entity.MemberRiskLevel" name="MemberRiskLevel"></input-text>
	        <input-text label="State" model="entity.State" name="State" disabled="disabled"></input-text>
	        <input-text label="Member Type" model="entity.MemberType" name="MemberType" disabled="disabled"></input-text>
            <input-text ng-if="entity.MemberType == 'Reseller'" label="Reseller Type" model="entity.Medal" name="Medal" disabled="disabled"></input-text>
            <input-check label="Staff Member" model="entity.IsStaffMember"></input-check>
		
	</div>
	
	<div class="col-xs-12 col-sm-6">
		<h3 class="header smaller lighter blue">Financial</h3>
		
	        <input-text label="Tax Office" model="entity.TaxOffice" name="TaxOffice"></input-text>
		
	        <input-text label="Tax Number" model="entity.TaxNumber" name="TaxNumber"></input-text>
		
	        <input-textarea label="Company Info" model="entity.CompanyInfo" name="CompanyInfo"></input-textarea>
		
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
