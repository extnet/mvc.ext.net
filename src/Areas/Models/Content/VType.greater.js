Ext.apply(Ext.form.VTypes, {
    greater : function (value, field, params) {
        return field.getValue() > Ext.net.findField(params.other, field).getValue();
    }
});