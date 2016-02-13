var CompanyX = {
   getCalendar : function () {
       return CompanyX.CalendarPanel1;
   },

   getStore : function () {
       return CompanyX.EventStore1;
   },

   getWindow : function () {
       return CompanyX.EventWindow1;
   },

   viewChange : function (p, vw, dateInfo) {
        var win = this.getWindow();

        if (win) {
            win.hide();
        }

        if (dateInfo) {
            // will be null when switching to the event edit form, so ignore
            this.DatePicker1.setValue(dateInfo.activeDate);
            this.updateTitle(dateInfo.viewStart, dateInfo.viewEnd);
        }
    },

    updateTitle : function (startDt, endDt) {
        var msg = '',
            fmt = Ext.Date.format;

        if (Ext.Date.clearTime(startDt).getTime() == Ext.Date.clearTime(endDt).getTime()) {
            msg = fmt(startDt, 'F j, Y');
        } else if (startDt.getFullYear() == endDt.getFullYear()) {
            if (startDt.getMonth() == endDt.getMonth()) {
                msg = fmt(startDt,'F j') + ' - ' + fmt(endDt, 'j, Y');
            } else {
                msg = fmt(startDt, 'F j') + ' - ' + fmt(endDt, 'F j, Y');
            }
        } else {
            msg = fmt(startDt, 'F j, Y') + ' - ' + fmt(endDt, 'F j, Y');
        }

        this.Panel1.setTitle(msg);
    },

    setStartDate : function (picker, date) {
        this.getCalendar().setStartDate(date);
    },

    rangeSelect : function (cal, dates, callback) {
        this.record.show(cal, dates);
        this.getWindow().on('hide', callback, cal, { single : true} );
    },

    dayClick : function (cal, dt, allDay, el) {
        this.record.show.call(this, cal, {
            StartDate : dt,
            IsAllDay  : allDay
        }, el);
    },

    record : {
        addFromEventDetailsForm : function (win, rec) {
            CompanyX.ShowMsg('Event ' + rec.data.Title + ' was added');
        },

        add : function (win, rec) {
            win.hide();
            CompanyX.getStore().add(rec);
            CompanyX.getStore().sync();
            CompanyX.ShowMsg('Event ' + rec.data.Title + ' was added');
        },

        updateFromEventDetailsForm : function (win, rec) {
            CompanyX.ShowMsg('Event ' + rec.data.Title + ' was updated');
        },

        update : function (win, rec) {
            win.hide();
            rec.commit();
            CompanyX.getStore().sync();
            CompanyX.ShowMsg('Event ' + rec.data.Title + ' was updated');
        },

        removeFromEventDetailsForm : function (win, rec) {
            CompanyX.ShowMsg('Event ' + rec.data.Title + ' was deleted');
        },

        remove : function (win, rec) {
            CompanyX.getStore().remove(rec);
            CompanyX.getStore().sync();
            win.hide();
            CompanyX.ShowMsg('Event ' + rec.data.Title + ' was deleted');
        },

        edit : function (win, rec) {
            win.hide();
            rec.commit();
            CompanyX.getCalendar().showEditForm(rec);
        },

        resize : function (cal, rec) {
            rec.commit();
            CompanyX.ShowMsg('Event '+ rec.data.Title + ' was updated');
        },

        move : function (cal, rec) {
            rec.commit();
            CompanyX.ShowMsg('Event '+ rec.data.Title + ' was moved to ' + Ext.Date.format(rec.data.StartDate, 'F jS' + (rec.data.IsAllDay ? '' : ' \\a\\t g:i a')));
        },

        show : function (cal, rec, el) {
            CompanyX.getWindow().show(rec, el);
        },

        saveAll : function () {
            CompanyX.getStore().submitData({
                mappings : false
            }, CompanyX.getStore().submitDataUrl);
        }
    }
};