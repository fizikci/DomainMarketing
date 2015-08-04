<div class="page-header">
    <h1>E-Mail Socket
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
            <input-text label="Name" model="entity.Name"></input-text>
            <input-text label="Host" model="entity.Host"></input-text>
            <input-text label="Username" model="entity.Username"></input-text>
            <input-text label="Password" model="entity.Password"></input-text>
            <input-number label="Port" model="entity.Port"></input-number>
            <input-text label="Credentials" model="entity.Credentials"></input-text>
            <input-select label="Delivery Format" model="entity.DeliveryFormat" options="i.Id as i.Name for i in EnumDeliveryFormats"></input-select>
            <input-select label="Delivery Method" model="entity.DeliveryMethod" options="i.Id as i.Name for i in EnumDeliveryMethods"></input-select>
            <input-check label="Enable Ssl" model="entity.EnableSsl"></input-check>
            <input-text label="Location" model="entity.PickupDirectoryLocation"></input-text>
            <input-text label="Target Name" model="entity.TargetName"></input-text>
            <input-number label="Timeout" model="entity.Timeout"></input-number>
            <input-text label="Cert File" model="entity.CertFile"></input-text>
            <input-text label="From" model="entity.MailFrom"></input-text>
            <input-text label="Sender" model="entity.Sender"></input-text>
            <input-text label="Reply" model="entity.Reply"></input-text>
            <input-number label="UnitPrice" model="entity.UnitPrice"></input-number>
            <input-number label="Capacity" model="entity.Capacity"></input-number>
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
