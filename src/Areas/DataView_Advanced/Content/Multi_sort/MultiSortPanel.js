Ext.define('Ext.multisort.Panel', {
    extend : 'Ext.panel.Panel',
    alias : 'widget.multisortpanel',
    
    requires : ['Ext.toolbar.TextItem', 'Ext.view.View'],
    
    initComponent : function () {
        this.tbar.defaults = {
            listeners : {
                scope : this,
                changeDirection : this.updateStoreSorters
            }
        };

        this.callParent(arguments);
        this.updateStoreSorters();
    },
    
    /**
     * Returns the array of Ext.util.Sorters defined by the current toolbar button order
     * @return {Array} The sorters
     */
    getSorters : function () {
        var buttons = this.query('toolbar sortbutton'),
            sorters = [];
        Ext.Array.each(buttons, function (button) {
            sorters.push({
                property  : button.getDataIndex(),
                direction : button.getDirection()
            });
        });
        
        return sorters;
    },
    
    /**
     * @private
     * Updates the DataView's Store's sorters based on the current Toolbar button configuration
     */
    updateStoreSorters: function () {
        var sorters = this.getSorters(),
            view = this.down('dataview');

        view.store.sort(sorters);
    }
});
