<div class="page-header">
    <h1 class="blue">
        <i class="icon-tag"></i>
        Order Item
    <small>
        <i class="icon-double-angle-right"></i>
        
    </small>
    </h1>
</div>

<div id="user-profile-1" class="user-profile row">
    <div class="col-xs-12 col-sm-3 center">
        <div>
            <span class="profile-picture">
                <i class="icon-tag" style="font-size: 50px"></i>
            </span>

            <div class="space-4"></div>

            <div class="width-80 label label-info label-xlg arrowed-in arrowed-in-right">
                <div class="inline position-relative">
                    <a class="user-title-label dropdown-toggle" data-toggle="dropdown">
                        <i class="icon-circle light-green"></i>
                        &nbsp;
                        <span class="white">{{entity.DisplayName}}</span>
                    </a>

                    <div style="clear:both;margin-bottom:60px"></div>

                    <a class="btn btn-lg btn-warning" href="/Staff/Handlers/DoCommand.ashx?method=cancelOrderItem&orderItemId={{entity.Id}}" onclick="return confirm('Sipariş satırı iptal edilecek! Devam?')">CANCEL</a>
                </div>
            </div>


        </div>

        <div class="hr hr16 dotted"></div>
    </div>

    <div class="col-xs-12 col-sm-9">

        <div class="profile-user-info profile-user-info-striped">
            <info-row label="Product"><a href="#/View/Product/{{entity.ProductId}}">{{entity.DisplayName}}</a></info-row>
            <info-row label="Amount">{{entity.Amount  +' '+ entity.Unit}}</info-row>
            <info-row label="Price">{{entity.Price/100 | currency}}</info-row>
        </div>


    </div>
</div>

