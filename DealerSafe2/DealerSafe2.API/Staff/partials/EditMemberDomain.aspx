<div class="page-header">
    <h1>Member Domain
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


            <input-text label="Domain Name" model="entity.DomainName"></input-text>
            <input-text label="Domain IDN" model="entity.DomainIDN"></input-text>
            <input-text label="ROID" model="entity.ROID"></input-text>
            <input-select label="Renewal Mode" model="entity.RenewalMode" options="i.Id as i.Name for i in EnumDomainRenewalModes"></input-select>
            <input-select label="Transfer Mode" model="entity.TransferMode" options="i.Id as i.Name for i in EnumDomainTransferModes"></input-select>
            <input-select label="Registry Status" model="entity.RegistryStatus" options="i.Id as i.Name for i in EnumRegistryStates"></input-select>
            <input-select label="RGP Status" model="entity.RGPStatus" options="i.Id as i.Name for i in EnumRGPStates"></input-select>
            <input-text label="Sponsor Id" model="entity.SponsorId"></input-text>
            <input-text label="Creator Id" model="entity.CreatorId"></input-text>
            <input-text label="Name Servers" model="entity.NameServers"></input-text>
            <input-text label="Host Names" model="entity.HostNames"></input-text>
            <input-text label="Zone Id" model="entity.ZoneId"></input-text>
            <input-text label="Owner Domain Contact Id" model="entity.OwnerDomainContactId"></input-text>
            <input-text label="Admin Domain Contact Id" model="entity.AdminDomainContactId"></input-text>
            <input-text label="Tech Domain Contact Id" model="entity.TechDomainContactId"></input-text>
            <input-text label="Billing Domain Contact Id" model="entity.BillingDomainContactId"></input-text>
            <input-select label="PrivacyProtection" model="entity.PrivacyProtection" options="i.Id as i.Name for i in EnumPrivacyProtectionOptions"></input-select>
            <input-text label="Auth Info" model="entity.AuthInfo"></input-text>
            <input-select label="Operational Status" model="entity.OperationalStatus" options="i.Id as i.Name for i in EnumOperationalStates"></input-select>
            <input-select label="Price Mode" model="entity.PriceMode" options="i.Id as i.Name for i in EnumOperationalStates"></input-select>
            <input-date label="Transfer Date" model="entity.TransferDate"></input-date>

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
