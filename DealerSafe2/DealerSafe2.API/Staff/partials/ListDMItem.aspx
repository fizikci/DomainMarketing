
<list-header title="DMItem"></list-header>

<pagination></pagination>

<table class="table table-striped table-bordered table-hover">
	<thead>
		<tr>
			<th></th>
			<th column-header="Type" field="Type"></th>
			<th column-header="Domain Name" field="DomainName"></th>
			<th column-header="Seller Member" field="SellerMemberName"></th>
			<th column-header="DMCategory" field="DMCategoryName"></th>
			<th column-header="Buy It Now Price" field="BuyItNowPrice"></th>
			<th column-header="Status" field="Status"></th>
			<th column-header="Expiry Date" field="ExpiryDate"></th>
			<th></th>
		</tr>
	</thead>
	<tbody>
		<tr ng-repeat="entity in list" ng-class="{deleted:entity.IsDeleted}">
			<td indexer></td>
			<td link-to-view>{{entity.Type}}</td>
			<td>{{entity.DomainName}}</td>
			<td link-to-parent="SellerMember">{{entity.SellerMemberName}}</td>
			<td link-to-parent="DMCategory">{{entity.DMCategoryName}}</td>
			<td>{{entity.BuyItNowPrice}}</td>
			<td>{{entity.Status}}</td>
			<td>{{entity.ExpiryDate}}</td>
			<td operations></td>
		</tr>
	</tbody>
</table>

<list-footer></list-footer>