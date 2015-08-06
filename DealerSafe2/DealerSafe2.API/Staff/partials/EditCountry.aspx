<div class="page-header">
    <h1>Country
            <small>
                <i class="icon-double-angle-right"></i>
                edit
            </small>
    </h1>
</div>

<form id="form" class="form-horizontal" role="form" autocomplete="off">

    <div class="row">
        <div class="col-sm-9"> 
            <input-id label="ID" model="entity.Id"></input-id>
			<input-text label="Name" name="Name" model="entity.Name"></input-text>
			<input-text label="Official Name" name="OfficialName" model="entity.OfficialName"></input-text>
			<input-text label="Utc Time Zone" name="UtcTimeZone" model="entity.UtcTimeZone"></input-text>
			<input-text label="Utc Time Zone Summer" name="UtcTimeZoneSummer" model="entity.UtcTimeZoneSummer"></input-text>
			<input-text label="Calling Code" name="CallingCode" model="entity.CallingCode"></input-text>
			<input-text label="Iso 2 Code" name="Iso2Code" model="entity.Iso2Code"></input-text>
			<input-text label="Iso 3 Code" name="Iso3Code" model="entity.Iso3Code"></input-text>
			<input-text label="Internet TLD" name="InternetTLD" model="entity.InternetTLD"></input-text>
			<input-text label="Currency Name" name="CurrencyName" model="entity.CurrencyName"></input-text>
			<input-text label="Offical Currency Name" name="OfficalCurrencyName" model="entity.OfficalCurrencyName"></input-text>
			<input-text label="Currency Iso Code" name="CurrencyIsoCode" model="entity.CurrencyIsoCode"></input-text>
			<input-text label="Currency Symbol" name="CurrencySymbol" model="entity.CurrencySymbol"></input-text>
			<input-text label="Flag" name="Flag" model="entity.Flag"></input-text>
            <input-number label="National Tax Rate" name="NationalTaxRate" model="entity.NationalTaxRate"></input-number>
			<input-text label="Identification Number Format" name="IdentificationNumberFormat" model="entity.IdentificationNumberFormat"></input-text>
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
