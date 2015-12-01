
<list-header title="DMBrokerage"></list-header>

<pagination></pagination>

<table class="table table-striped table-bordered table-hover">
	<thead>
		<tr>
			<th></th>
			<th column-header="Requester Member" field="RequesterMemberName"></th>
			<th column-header="Broker Member" field="BrokerMemberName"></th>
			<th column-header="DMItem" field="DMItemName"></th>
			<th column-header="Status" field="Status"></th>
			<th></th>
		</tr>
	</thead>
	<tbody>
		<tr ng-repeat="entity in list" ng-class="{deleted:entity.IsDeleted}">
			<td indexer></td>
			<td link-to-parent="RequesterMember">{{entity.RequesterMemberName}}</td>
			<td link-to-parent="BrokerMember">{{entity.BrokerMemberName}}</td>
			<td link-to-parent="DMItem">{{entity.DMItemName}}</td>
			<td>{{entity.Status}}</td>
			<td operations></td>
		</tr>
	</tbody>
</table>

<list-footer></list-footer>