
<list-header title="DMOffer"></list-header>

<pagination></pagination>

<table class="table table-striped table-bordered table-hover">
	<thead>
		<tr>
			<th></th>
			<th column-header="DMItem" field="DMItemId"></th>
			<th column-header="Offerer Member" field="OffererMemberName"></th>
			<th column-header="Offer Value" field="OfferValue"></th>
			<th></th>
		</tr>
	</thead>
	<tbody>
		<tr ng-repeat="entity in list" ng-class="{deleted:entity.IsDeleted}">
			<td indexer></td>
			<td link-to-view>{{entity.DMItemId}}</td>
			<td link-to-parent="OffererMember">{{entity.OffererMemberName}}</td>
			<td>{{entity.OfferValue}}</td>
			<td operations></td>
		</tr>
	</tbody>
</table>

<list-footer></list-footer>