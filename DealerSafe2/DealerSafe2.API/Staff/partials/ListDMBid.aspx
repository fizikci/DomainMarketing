
<list-header title="DMBid"></list-header>

<pagination></pagination>

<table class="table table-striped table-bordered table-hover">
	<thead>
		<tr>
			<th></th>
			<th column-header="DMItem" field="DMItemName"></th>
			<th column-header="Bidder Member" field="BidderMemberName"></th>
			<th column-header="Bid Value" field="BidValue"></th>
			<th column-header="Is Offer" field="IsOffer"></th>
			<th></th>
		</tr>
	</thead>
	<tbody>
		<tr ng-repeat="entity in list" ng-class="{deleted:entity.IsDeleted}">
			<td indexer></td>
			<td link-to-parent="DMItem">{{entity.DMItemName}}</td>
			<td link-to-parent="BidderMember">{{entity.BidderMemberName}}</td>
			<td>{{entity.BidValue}}</td>
			<td>{{entity.IsOffer}}</td>
			<td operations></td>
		</tr>
	</tbody>
</table>

<list-footer></list-footer>