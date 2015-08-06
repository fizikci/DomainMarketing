<div class="page-header">
    <h1>Reseller
        <small><i class="icon-double-angle-right"></i>edit</small>
    </h1>
</div>

<form id="form" class="form-horizontal" role="form" autocomplete="off">

    <input type="text" ng-model="entity.Id" name="Id" style="display: none" />

    <div class="row">


        <div class="col-sm-9">


            <input-select label="Partner Rozerti" model="entity.ResellerTypeId" options="i.Id as i.Name for i in ResellerTypes"></input-select>
            <input-number label="Setup / Kayıt Ücreti" model="entity.SetupRegisterFee"></input-number>
            <input-number label="Ön ödemeli Kredi Şartı" model="entity.PrePaidCreditAmount"></input-number>
            <input-number label="Kabul edilen min. Ek kredi" model="entity.MinAdditionalCreditAmount"></input-number>
            <h4 class="header smaller bullet_black">Ek süre için gereken krediler</h4>
            <div class="form-group">
                <label for="Name" class="col-sm-3 control-label no-padding-right"></label>
                <div class="col-sm-9">
                    + 0 gün  $
                    <input ng-model="entity.AdditionalDays0StartFee" type="number" name="AdditionalDays0StartFee" />
                    - $
                    
                    <input ng-model="entity.AdditionalDays0EndFee" type="number" name="AdditionalDays0EndFee" />
                </div>
            </div>
            <div class="form-group">
                <label for="Name" class="col-sm-3 control-label no-padding-right"></label>
                <div class="col-sm-9">
                    +30 gün  $
                    <input ng-model="entity.AdditionalDays30StartFee" type="number" name="AdditionalDays30StartFee" />
                    - $
                    
                    <input ng-model="entity.AdditionalDays30EndFee" type="number" name="AdditionalDays30EndFee" />
                </div>
            </div>
            <div class="form-group">
                <label for="Name" class="col-sm-3 control-label no-padding-right"></label>
                <div class="col-sm-9">
                    +90 gün  $
                    <input ng-model="entity.AdditionalDays90StartFee" type="number" name="AdditionalDays90StartFee" />
                    - $
                    
                    <input ng-model="entity.AdditionalDays90EndFee" type="number" name="AdditionalDays90EndFee" />
                </div>
            </div>
            <h3 class="header smaller bullet_black"></h3>
            <input-check label="MDF katılım hakkı" model="entity.CanJoinMdf"></input-check>
            <input-select label="Partner Ağında Listelenme" model="entity.ListInPartnerNetwork" options="i.Id as i.Name for i in EnumListInPartnerNetwork"></input-select>
            <input-select label="Destek Grubu" model="entity.SupportGroup" options="i.Id as i.Name for i in EnumSupportGroup"></input-select>
            <input-number label="İndirim Oranı" model="entity.RebateRate"></input-number>
            <input-check label="Nakit Geri Ödeme" model="entity.CashRefund"></input-check>
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
