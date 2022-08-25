(function () {
    angular.module('umbraco')
        .component('customTreePickerItem', {
            bindings: {
                item: '<',
                depth: '<'
            },
            require: {
                tree: '^customTreePicker'
            },
            template: `
                <div class="link" ng-class="{selected: vm.item.selected, disabled: vm.item.disabled}" ng-style="{ paddingLeft: 20 * vm.depth + 'px'}">
                    <button data-element="tree-item-expand"
                         class="umb-tree-item__arrow umb-outline btn-reset"
                         ng-class="{'icon-navigation-right': !vm.item.expanded, 'icon-navigation-down': vm.item.expanded}"
                         ng-style="{'visibility': vm.item.hasChildren ? 'visible' : 'hidden'}"
                         ng-click="vm.toggleChildren()">&nbsp;
                         <!-- TODO: Use localization for this text -->
                        <span class="sr-only">Expand child items for {{vm.item.name}}</span>
                    </button>
                    <i class="icon umb-tree-icon sprTree" ng-class="::vm.item.icon" title="{{::vm.item.title}}" ng-click="vm.toggle()" tabindex="-1"></i>
                    <span class="umb-tree-item__annotation"></span>
                    <a class="umb-tree-item__label" ng-click="vm.toggle()" title="{{::vm.item.title}}">{{vm.item.name}}</a>
                    <umb-loader ng-show="vm.loading" position="bottom" class="umb-tree-item__loader"></umb-loader>
                </div>
                <div ng-if="vm.children && vm.item.expanded">
                    <custom-tree-picker-item item="item" depth="vm.depth+1" ng-repeat="item in vm.children"></custom-tree-picker-item>
                </div>
            `,
            controller: CustomTreePickerItemController,
            controllerAs: 'vm'
        });

    CustomTreePickerItemController.$inject = []
    function CustomTreePickerItemController() {
        var vm = this;

        vm.$onInit = function () {
        }

        vm.toggle = function () {
            if (!vm.item.disabled) {
                vm.item.selected = !vm.item.selected;
                vm.tree.toggleItem(vm.item);
            }
        }

        vm.toggleChildren = function () {
            if (vm.item.hasChildren) {
                vm.item.expanded = !vm.item.expanded;
                if (vm.item.hasChildren && !vm.children) {
                    vm.loading = true;
                    vm.tree.getItems(vm.item.id)
                        .then(function (items) {
                            vm.children = items;
                            vm.loading = false;
                        })
                }
            }
        }
    }
})();