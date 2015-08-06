<list-header title="Product Types"></list-header>

<div class="row">
    
	<div class="col-xs-12 col-sm-4 widget-container-span"  ng-repeat="pt in list" ng-class="{deleted:pt.IsDeleted}" style="margin-top:12px">
		<div class="widget-box">
			<div class="widget-header">
			    <h5>
			        <span ng-if="renamePt!=pt" ng-click="rename(pt)">{{pt.Name}}</span>
                    <input ng-if="renamePt==pt" ng-model="pt.Name" ng-enter="renameSave()" class="form-control" id="{{pt.Id}}" type="text" style="width: 65%;float: left;height: 24px;margin-top: 6px;"/>
			    </h5>

				<div class="widget-toolbar">
					<a ng-if="renamePt!=pt" ng-click="rename(pt)" data-action="settings">
						<i class="icon-edit"></i>
					</a>
					<a ng-if="renamePt==pt" ng-click="renameCancel()" data-action="close">
						<i class="icon-remove"></i>
					</a>
				</div>
			</div>
            
			<div class="widget-body">
			    <div class="widget-main">
			        <div ng-if="!pt.currProp">
			            {{pt.ProductCount}} products with <a ng-click="readProps(pt, true)" style="font-weight:{{pt.props.length?'bold':'normal'}}">{{pt.PropertyCount}} properties</a>.
			            <table ng-if="pt.props" class="table table-bordered" style="margin-top: 20px">
                            <tbody ng-repeat="groupProps in pt.props | groupBy: 'GroupName' | toArray:true | orderBy:min">
                            <tr class="group"><td colspan="2"><b>{{groupProps.$key || ''}}</b></td></tr>
			                <tr ng-repeat="pp in groupProps | orderBy:'OrderNo'" ng-class="{deleted:pp.IsDeleted}">
			                    <td>
			                        <i class="icon-ok green"></i>
			                        {{pp.Name}}
			                    </td>
			                    <td>
			                        <i class="icon-edit orange" ng-click="editProp(pt, pp)"></i>
			                        <i class="icon-trash red" ng-click="deleteProp(pt, pp)"></i>
                                    <i class="icon-long-arrow-up green" ng-click="upProp(pt, pp)"></i>
                                    <i class="icon-long-arrow-down green" ng-click="downProp(pt, pp)"></i>
			                    </td>
			                </tr>
                            </tbody>
			            </table>
                        <div class="text-right">
			                <a class="btn btn-link" ng-click="newProp(pt)">
			                    <i class="icon-plus bigger-110"></i>
			                    Add property
			                </a>
			            </div>
                    </div>
                    
			        <div ng-if="pt.currProp">
			            <form class="form-horizontal" role="form" autocomplete="off">
			                <input type="text" ng-model="pt.currProp.Id" name="Id" style="display:none"/>
			                <input type="text" ng-model="pt.currProp.ProductTypeId" name="ProductTypeId" style="display:none"/>
			                <div class="row">
			                    <input-text label="Group" model="pt.currProp.GroupName"></input-text>
			                    <input-text label="Name" model="pt.currProp.Name"></input-text>
			                    <input-select label="Type" model="pt.currProp.PropType" options="i for i in ['string','options','int','date','bool','money']"></input-select>
                                <input-text ng-show="pt.currProp.PropType=='options'" label="Options" model="pt.currProp.Options"></input-text>
                                <input-text label="Default" model="pt.currProp.DefaultValue"></input-text>
			                    <input-check label="Public" model="pt.currProp.Public"></input-check>
			                </div>

			                <div class="clearfix form-actions">
			                    <div class="text-right">
			                        <button class="btn btn-xs btn-primary" type="button" ng-click="saveProp(pt)">
			                            <i class="icon-ok bigger-110"></i>
			                            Save
			                        </button>
			                        &nbsp; 
			                        <button class="btn btn-xs btn-info" type="button" ng-click="cancelEditProp(pt)">
			                            <i class="icon-undo bigger-110"></i>
			                            Cancel
			                        </button>
			                    </div>
			                </div>

			            </form>
			        </div>
                    
			    </div>
			</div>
		</div>
	</div>
    
</div>

<list-footer></list-footer>
