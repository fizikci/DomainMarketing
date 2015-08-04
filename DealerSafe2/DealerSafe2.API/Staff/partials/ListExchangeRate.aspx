<list-header title="Exchange Rates"></list-header>

<pagination></pagination>

<table class="table table-striped table-bordered table-hover">
    <thead>
        <tr>
            <th></th>
            <th column-header="Date" field="InsertDate"></th>
            <th column-header="Exchange Rate" field="Currency"></th>
            <th></th>
        </tr>
    </thead>
    <tbody>
        <tr ng-repeat="entity in list" ng-class="{deleted:entity.IsDeleted}">
            <td indexer></td>
            <td link-to-edit>{{entity.InsertDate | date:'dd-MM-yyyy'}}</td>
            <td>1 {{entity.Currency}} = {{entity.PriceTL/1000000 | number:6}} TL</td>
            <td operations></td>
        </tr>
    </tbody>
</table>

<list-footer></list-footer>