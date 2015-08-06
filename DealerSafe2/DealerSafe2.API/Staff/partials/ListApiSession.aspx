<list-header title="Sessions"></list-header>

<pagination></pagination>

<table class="table table-striped table-bordered table-hover">
	<thead>
		<tr>
			<th></th>
			<th column-header="Member" field="MemberName"></th>
			<th column-header="First Access" field="InsertDate"></th>
			<th column-header="Login Date" field="LoginDate"></th>
			<th column-header="Last Access" field="LastAccess"></th>
			<th></th>
		</tr>
	</thead>
	<tbody>
		<tr ng-repeat="entity in list" ng-class="{deleted:entity.IsDeleted}">
			<td indexer></td>
			<td link-to-parent="Member">{{entity.MemberName}}</td>
			<td>{{entity.InsertDate | date:'yyyy-MM-dd HH:mm'}}</td>
			<td>{{entity.LoginDate | date:'yyyy-MM-dd HH:mm'}}</td>
			<td>{{entity.LastAccess | date:'yyyy-MM-dd HH:mm'}}</td>
			<td operations></td>
		</tr>
	</tbody>
</table>

<list-footer></list-footer>