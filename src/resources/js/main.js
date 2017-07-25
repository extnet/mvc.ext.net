var handleRedirection = function () {
    if (Ext.os.deviceType !== "Desktop") {
        var query = Ext.Object.fromQueryString(window.location.search),
            queryRedirect = query.redirect;

        if (!Ext.isEmpty(queryRedirect)) {
            queryRedirect = Ext.JSON.decode(queryRedirect);

            if (queryRedirect === false) {
                return;
            } else if (queryRedirect === true) {
                window.location = "http://mobile.ext.net";
                return;
            }
        }

        var cookieRedirect = Ext.util.Cookies.get("redirect");

        if (!Ext.isEmpty(cookieRedirect)) {
            cookieRedirect = Ext.JSON.decode(cookieRedirect);

            if (cookieRedirect === false) {
                return;
            } else if (cookieRedirect === true) {
                window.location = "http://mobile.ext.net";
                return;
            }
        }

        // Rich this code if neither query string nor Cookie directives
        // So, we should ask the user eiter redirect or stay
        Ext.onReady(function () {
            App.RedirectOverlay.show();
        });
    }
};

handleRedirection();

Ext.grid.NavigationModel.override({
    onKeyUp: function (keyEvent) {
        var newRecord = keyEvent.view.walkRecs(keyEvent.record, -1);

        if (newRecord && newRecord !== keyEvent.record) {
            this.setPosition(newRecord, this.columnIndex, keyEvent);
        } else {
            keyEvent.view.getSelectionModel().deselectAll();
            App.SearchField.focus(false, 100);
        }
    }
});

Ext.onReady(function () {
    var sidebarRight = document.getElementById('rightnav-body');
    Ps.initialize(sidebarRight);

    Ext.get("menu-button", true).on({
        click: function () {
            App.rightnav[App.rightnav.isHidden() ? "show" : "hide"]();
            Ps.update(sidebarRight);
        }
    });

    Ext.select("[data-toggle='collapse'", true).on({
        click: function (e) {
            e.preventDefault();

            this.toggleCls("expanded");
            Ext.get((this.getAttribute("data-target")).substring(1)).toggleCls("expanded");
        }
    });
});

var SEARCH_URL = "/search/",
    TAG_CLOUD_TOKEN = "/TagCloud",
    lockHistoryChange = false;

var tagLabelConfig = {
    trackOver: true,
    listeners: {
        beforetagadd: function (field, tag, o) {
            tag.overCls = "example-tag";
            o["data-qtip"] = "Click to filter examples by '" + tag.text + "'";
        },
        click: function (field, tag) {
            var searchField = App.SearchField;

            searchField.setValue(tag.text);
            changeFilterHash(tag.text.replace(" ", "+"));
            filter(searchField, true);
        }
    }
};

var createTagItems = function (tab, node) {
    var tb = tab.getDockedItems('toolbar[dock="top"]')[0];

    tb.insert(1, {
        xtype: "tbseparator"
    });

    if (node.data.tags.length > 0) {
        tb.insert(2, Ext.applyIf({
            xtype: "taglabel",
            tags: node.data.tags
        }, tagLabelConfig));
    }
};


var makeTab = function (id, url, title) {
    var win,
        tab,
        hostName,
        exampleName,
        node,
        tabTip;

    if (id === "-") {
        id = Ext.id(undefined, "extnet");
        lookup[url] = id;
    }

    tabTip = url.replace(/^\//g, "");
    tabTip = tabTip.replace(/\/$/g, "");
    tabTip = tabTip.replace(/\//g, " > ");
    tabTip = tabTip.replace(/_/g, " ");

    win = new Ext.window.Window({
        id: "w" + id,
        layout: "fit",
        title: "Source Code",
        iconCls: "fa fa-code",
        width: 925,
        height: 650,
        border: false,
        maximizable: true,
        constrain: true,
        closeAction: "hide",
        listeners: {
            show: {
                fn: function () {
                    var me = this,
                        height = Ext.getBody().getViewSize().height;

                    if (this.getSize().height > height) {
                        this.setHeight(height - 20)
                    }

                    App.direct.GetSourceTabs(id, url, this.nsId, {
                        eventMask: {
                            showMask: true,
                            customTarget: this.body
                        },
                        failure: function (msg, response) {
                            Ext.Msg.alert("Failure", "The error during example loading:\n" + response.responseText);
                        }
                    });
                },

                single: true
            }
        },
        buttons: [
            {
                id: "b" + id,
                text: "Download",
                iconCls: "fa fa-download",
                listeners: {
                    click: {
                        fn: function (el, e) {
                            App.direct.DownloadExample(url, {
                                isUpload: true,
                                formId: "downloadForm"
                            });
                        }
                    }
                }
            }
        ]
    });

    hostName = window.location.protocol + "//" + window.location.host;
    exampleName = url;

    tab = App.ExampleTabs.add(new Ext.panel.Panel({
        id: id,
        tbar: [{
            text: "Source Code",
            iconCls: "fa fa-code",
            listeners: {
                "click": function () {
                    Ext.getCmp("w" + id).show(null);
                }
            }
        },
        "->",
        {
            text: "Direct Link",
            iconCls: "fa fa-link",
            handler: function () {
                new Ext.window.Window({
                    modal: true,
                    iconCls: "fa fa-link",
                    layout: "absolute",
                    defaultButton: "dl" + id,
                    width: 400,
                    height: 140,
                    title: "Direct Link",
                    closable: false,
                    resizable: false,
                    items: [{
                        id: "dl" + id,
                        xtype: "textfield",
                        cls: "dlText",
                        width: 364,
                        x: 10,
                        y: 10,
                        selectOnFocus: true,
                        readOnly: true,
                        value: hostName + "/#" + exampleName
                    }],
                    buttons: [{
                        xtype: "button",
                        text: " Open",
                        iconCls: "fa fa-external-link",
                        tooltip: "Open Example in the separate window",
                        handler: function () {
                            window.open(hostName + "/#" + exampleName);
                        }
                    },
                    {
                        xtype: "button",
                        text: " Open (Direct)",
                        iconCls: "fa fa-external-link-square",
                        tooltip: "Open Example in the separate window using a direct link",
                        handler: function () {
                            window.open(hostName + url, "_blank");
                        }
                    },
                    {
                        xtype: "button",
                        text: "Close",
                        handler: function () {
                            this.findParentByType("window").hide(null);
                        }
                    }]
                }).show(null);
            }
        },
        "-",
        {
            text: "Refresh",
            handler: function () {
                Ext.getCmp(id).reload(true)
            },
            iconCls: "fa fa-refresh"
        }],
        title: title,
        tabTip: tabTip,
        hideMode: "offsets",

        loader: {
            renderer: "frame",
            url: hostName + url,
            listeners: {
                beforeload: function () {
                    this.target.body.mask('Loading...');
                },
                load: function (loader) {
                    this.target.body.unmask();
                }
            }
        },
        listeners: {
            deactivate: {
                fn: function (el) {
                    if (this.sWin && this.sWin.isVisible()) {
                        this.sWin.hide();
                    }
                }
            },

            destroy: function () {
                if (this.sWin) {
                    this.sWin.close();
                    this.sWin.destroy();
                }
            }
        },
        closable: true
    }));

    tab.sWin = win;
    setTimeout(function () {
        App.ExampleTabs.setActiveTab(tab);
    }, 250);

    var node = App.exampleTree.getStore().getNodeById(id),
        expandAndSelect = function (node) {
            var view = App.exampleTree.getView(),
                originalAnimate = view.animate;

            view.animate = false;
            node.bubble(function (node) {
                node.expand(false);
            });

            App.exampleTree.getSelectionModel().select(node);
            view.animate = originalAnimate;
        };

    if (node) {
        expandAndSelect(node);
        createTagItems(tab, node);
    } else {
        App.exampleTree.on("load", function (node) {
            node = App.exampleTree.getStore().getNodeById(id);
            if (node) {
                expandAndSelect(node);
                createTagItems(tab, node);
            }
        }, this, { delay: 10, single: true });
    }
};

var lookup = {};

var onTreeAfterRender = function (tree) {
    var sm = tree.getSelectionModel();

    Ext.create('Ext.util.KeyNav', {
        target: tree.view.el,
        enter: function (e) {
            if (sm.hasSelection()) {
                onTreeItemClick(sm.getSelection()[0], e);
            }
        }
    });
};

var onTreeItemClick = function (record, e) {
    if (record.isLeaf()) {
        e.stopEvent();
        loadExample(record.get('url'), record.getId(), record.get('text'));
    } else {
        record[record.isExpanded() ? 'collapse' : 'expand']();
    }
};

var treeRenderer = function (value, metadata, record) {
    if (record.data.flags) {
        if (record.data.flags == "n") {
            value += "<span>New</span>";
        } else if (record.data.flags == "u") {
            value += "<span>Update</span>";
        }
    }

    return value;
};

var loadExample = function (href, id, title) {
    var tab = App.ExampleTabs.getComponent(id),
        lObj = lookup[href];

    var slashFields = href.split("/");
    if (slashFields.length > 3) {
        href = "";
        for (var i in [0, 1, 2]) {
            href = href + slashFields[i] + "/"
        }
    } else if(href[href.length - 1] != "/") {
        href = href + "/";
    }

    if (id == "-") {
        App.direct.GetHashCode(href, {
            success: function (result) {
                loadExample(href, "e" + result, title);
            }
        });

        return;
    }

    lookup[href] = id;

    if (tab) {
        App.ExampleTabs.setActiveTab(tab);
    } else {
        if (Ext.isEmpty(title)) {
            var m = /(\w+)\/$/g.exec(href);
            title = m == null ? "[No name]" : m[1];
        }

        title = title.replace(/<span>&nbsp;<\/span>/g, "");
        title = title.replace(/_/g, " ");
        makeTab(id, href, title);
    }
};

var viewClick = function (dv, e) {
    var group = e.getTarget("h2", 3, true);

    if (group) {
        group.up("div").toggleClass("collapsed");
    }
};

var beforeSourceShow = function (el) {
    var height = Ext.getBody().getViewSize().height;

    if (el.getSize().height > height) {
        el.setHeight(height - 20);
    }
};

var change = function (token) {
    if (!lockHistoryChange) {
        if (token) {
            if (token.indexOf(SEARCH_URL) === 0) {
                filterByUrl(token);
            } else if (token === TAG_CLOUD_TOKEN) {
                showTagCloud();
            } else {
                loadExample(token, lookup[token] || "-");
            }
        } else {
            App.ExampleTabs.setActiveTab(0);
        }
    }
    lockHistoryChange = false;
};

var getToken = function (url) {
    var host = window.location.protocol + "//" + window.location.host;

    return url.substr(host.length);
};

var addToken = function (el, tab) {
    if (tab.loader && tab.loader.url) {
        var token = getToken(tab.loader.url);

        Ext.History.add(token);
    } else if (tab.historyToken) {
        Ext.History.add(tab.historyToken);
    } else {
        Ext.History.add("");
    }
};

var keyUp = function (field, e) {
    if (e.getKey() === 40) {
        return;
    }

    if (e.getKey() === Ext.event.Event.ESC) {
        clearFilter(field);
    } else {
        changeFilterHash(field.getRawValue().replace(" ", "+"));
        filter(field);
    }
};

/*
    field: the search field
    byTagsOnly: true means searcing by tags only and by full matching
*/
var filter = function (field, byTagsOnly) {
    var tree = App.exampleTree,
        text = field.getRawValue(),
        view = tree.getView(),
        originalAnimate = view.animate;

    if (Ext.isEmpty(text, false)) {
        clearFilter(field);
        return;
    }

    if (text.length < 2) {
        return;
    }

    field.getTrigger(0).show();

    var re = new RegExp(".*" + text + ".*", "i");

    tree.clearFilter(true);

    tree.filterBy(function (node) {
        var tags = node.data.tags,
            hasTags = Ext.isArray(node.data.tags) && node.data.tags.length > 0,
            match = false,
            pn = node.parentNode,
            pnIsFixed = false,
            i, len,
            tagMatch = false;

        if (App.SearchByTitles.checked && !byTagsOnly) {
            match = re.test(node.data.text);
        }

        if ((App.SearchByTags.checked || byTagsOnly) && hasTags) {
            if (byTagsOnly) {
                match = match || Ext.Array.contains(tags, text);
            } else {
                for (i = 0, len = tags.length; i < len; i++) {
                    if (re.test(tags[i])) {
                        match = true;
                        break;
                    }
                }
            }
        }

        if (match && node.isLeaf()) {
            pn.hasMatchNode = true;
        }

        if (pn) {
            node.bubble(function (n) {
                if (node != n) {
                    pnIsFixed = re.test(n.data.text);

                    return !pnIsFixed;
                }
            });
        }

        if (pn != null && pnIsFixed) {
            return true;
        }

        if (node.isLeaf() === false) {
            return match;
        }

        return pnIsFixed || match;
    }, { expandNodes: false });

    view.animate = false;
    tree.getRootNode().cascadeBy(function (node) {
        if (node.isRoot()) {
            return;
        }

        if ((node.getDepth() === 1) ||
            (node.getDepth() === 2 && node.hasMatchNode)) {
            node.expand(false);
        }

        delete node.hasMatchNode;
    }, tree);

    view.animate = originalAnimate;
};

var filterByUrl = function (url) {
    var field = App.SearchField,
        tree = App.exampleTree;

    if (!lockHistoryChange) {
        var tree = App.exampleTree,
            store = tree.getStore(),
            fn = function () {
                field.setValue(url.substr(SEARCH_URL.length).replace("+", " "));
                filter(field);
            };

        if (store.loading) {
            store.on("load", fn, null, { single: true, delay: 100 });
        } else {
            fn();
        }
    }
};

var clearFilter = function (field, trigger, index, e) {
    var tree = App.exampleTree;

    field.setValue("");
    changeFilterHash("");
    field.getTrigger(0).hide();
    tree.clearFilter(true);
    field.focus(false, 100);
};

var changeFilterHash = Ext.Function.createBuffered(
    function (text) {
        lockHistoryChange = true;
        if (text.length > 2) {
            window.location.hash = SEARCH_URL + text;
        } else {
            var tab = App.ExampleTabs.getActiveTab(),
                token = "";

            if (tab.loader && tab.loader.url) {
                token = getToken(tab.loader.url);
            }

            Ext.History.add(token);
        }
    },
    500);

var filterSpecialKey = function (field, e) {
    var tree = App.exampleTree,
        view = tree.getView();

    if (e.getKey() === e.DOWN) {
        var n = tree.getRootNode().findChildBy(function (node) {
            return node.isLeaf() && node.data.visible;
        }, tree, true);

        if (n) {
            tree.expandPath(n.getPath(), null, null, function () {
                tree.getSelectionModel().select(n);
            });
        }
    }
};

var filterNewExamples = function (checkItem, checked) {
    var tree = App.exampleTree;

    if (checked) {
        tree.clearFilter(true);
        tree.filterBy(function (node) {
            return node.data.isNew;
        });
    } else {
        tree.clearFilter(true);
    }
};

var swapThemeClass = function (frame, oldTheme, newTheme) {
    var html = Ext.fly(frame.document.body.parentNode);

    html.removeCls('x-theme-' + oldTheme);
    html.addCls('x-theme-' + newTheme);
};

var themeChange = function (menu, menuItem) {
    App.direct.SetTheme(menuItem.text, {
        success: function (result) {
            App.ExampleTabs.items.each(function(tab) {
                if (tab.id !== "tabHome") {
                    tab.getBody().location.reload();
                }
            });
        }
    });
};

var getAllTags = function () {
    var tags = [],
        root = App.exampleTree.getRootNode();

    root.cascadeBy(function (node) {
        if (Ext.isArray(node.data.tags)) {
            tags = tags.concat(node.data.tags)
        }
    });

    tags = Ext.Array.unique(tags);

    return Ext.Array.sort(tags);
};

var showTagCloud = function () {
    var tabPanel = App.ExampleTabs,
        tabId = "tagCloudTab",
        tab = tabPanel.getComponent(tabId);

    if (!tab) {
        tab = Ext.create("Ext.panel.Panel", {
            id: tabId,
            title: "Tag Cloud",
            icon: "#WeatherClouds",
            closable: true,
            url: "TagCloud",
            margin: 20,
            historyToken: TAG_CLOUD_TOKEN,
            items: [
                Ext.applyIf({
                    xtype: "taglabel",
                    tags: getAllTags()
                }, tagLabelConfig)
            ]
        });

        tabPanel.addTab(tab);
    }

    tabPanel.setActiveTab(tab);
};

if (window.location.href.indexOf("#") > 0) {
    var directLink = window.location.href.substr(window.location.href.indexOf("#") + 1)
                    .replace(/(\s|\<|&lt;|%22|%3C|\"|\'|&quot|&#039;|script)/gi, '');

    Ext.onReady(function () {
        Ext.Function.defer(function () {
            if (directLink.indexOf(SEARCH_URL) === 0) {
                filterByUrl(directLink);
            } else {
                if (!Ext.isEmpty(directLink, false)) {
                    if (directLink === TAG_CLOUD_TOKEN) {
                        if (App.exampleTree.store.loading) {
                            App.exampleTree.store.on("load", function () {
                                showTagCloud();
                            }, null, { single: true })
                        } else {
                            showTagCloud();
                        }
                    } else {
                        loadExample(directLink, "-");
                    }
                }
            }
        }, 100, window);
    }, window);
}

var onRedirect = function () {
    var remember = App.RememberCheckbox.getValue();

    if (remember) {
        Ext.util.Cookies.set("redirect", true);
    }

    window.location = "http://mvc.mobile.ext.net";
};

var onStay = function () {
    var remember = App.RememberCheckbox.getValue();

    if (remember) {
        Ext.util.Cookies.set("redirect", false);
    }

    this.up().hide();
};