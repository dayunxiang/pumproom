// ajax加载调试用
//# sourceURL=base-BaiduMap.js

//BaiduMapObj 百度地图扩展--created by zouqj 2017-8-24
var BaiduMapObj = (function () {
    var map = null;
    var iconObj = { w: 21, h: 21, l: 0, t: 0, x: 6, lb: 5 }
    //创建一个Icon
    var createIcon = function (json) {
        var icon = new BMap.Icon("http://map.baidu.com/image/us_mk_icon.png", new BMap.Size(json.w, json.h), { imageOffset: new BMap.Size(-json.l, -json.t), infoWindowOffset: new BMap.Size(json.lb + 5, 1), offset: new BMap.Size(json.x, json.h) })
        return icon;
    }    
    //搜索地区(地区）
    this.searchMap = function (id, txtWords) {
        var area = document.getElementById(txtWords).value; //得到地区
        var ls = new BMap.LocalSearch(map);
        ls.setSearchCompleteCallback(function (rs) {
            if (ls.getStatus() == BMAP_STATUS_SUCCESS) {
                var poi = rs.getPoi(0);
                if (poi) {
                    BaiduMapObj.init(id, poi.point.lng, poi.point.lat);
                    
                }
            }
        });
        ls.search(area);
        
       
    };
    //创建地图函数：
    this.createMap=function(id,x, y, _level) {
        var map = new BMap.Map(id);//在百度地图容器中创建一个地图
        var point = new BMap.Point(x, y);//定义一个中心点坐标
        map.centerAndZoom(point, _level);//设定地图的中心点和坐标并将地图显示在地图容器中
        return map;
    }
    this.setAllView = function (map) {
        var stCtrl = new BMap.PanoramaControl(); //构造全景控件
        stCtrl.setOffset(new BMap.Size(20, 20));
        map.addControl(stCtrl);//添加全景控件
        return map;
    }

    //地图事件设置函数：
    this.setMapEvent = function (map) {
        map.enableDragging();//启用地图拖拽事件，默认启用(可不写)
        map.enableScrollWheelZoom();//启用地图滚轮放大缩小
        map.enableDoubleClickZoom();//启用鼠标双击放大，默认启用(可不写)
        map.enableKeyboard();//启用键盘上下左右键移动地图
    }
    
    //地图控件添加函数：
    this.addMapControl = function (map) {
        //向地图中添加缩放控件
        var ctrl_nav = new BMap.NavigationControl({ anchor: BMAP_ANCHOR_TOP_LEFT, type: BMAP_NAVIGATION_CONTROL_LARGE });
        map.addControl(ctrl_nav);
        //向地图中添加缩略图控件
        var ctrl_ove = new BMap.OverviewMapControl({ anchor: BMAP_ANCHOR_BOTTOM_RIGHT, isOpen: 1 });
        map.addControl(ctrl_ove);
        //向地图中添加比例尺控件
        var ctrl_sca = new BMap.ScaleControl({ anchor: BMAP_ANCHOR_BOTTOM_LEFT });
        map.addControl(ctrl_sca);

        var stCtrl = new BMap.PanoramaControl(); //构造全景控件
        stCtrl.setOffset(new BMap.Size(20, 20));
        map.addControl(stCtrl);//添加全景控件
    }
    
    //创建marker
    this.addMarker = function (map,markerArr) {
        for (var i = 0; i < markerArr.length; i++) {
            var json = markerArr[i];
            var p0 = json.point.split("|")[0];
            var p1 = json.point.split("|")[1];
            var point = new BMap.Point(p0, p1);
            //var iconImg = createIcon(icon);
            var marker = new BMap.Marker(point);//创建图标 , { icon: iconImg }
            //var iw = createInfoWindow(i);
            var label = new BMap.Label(json.title, { "offset": new BMap.Size(iconObj.lb - iconObj.x + 10, -20) });
            marker.setLabel(label);
            map.addOverlay(marker);
            marker.setAnimation(BMAP_ANIMATION_BOUNCE); //跳动的动画
            label.setStyle({
                borderColor: "#808080",
                color: "#333",
                cursor: "pointer",
                border: "0px",
                'background-color': ""
            });

            //(function () {
            //    var index = i;
            //    var _iw = createInfoWindow(i);
            //    var _marker = marker;
            //    _marker.addEventListener("click", function () {
            //        this.openInfoWindow(_iw);
            //    });
            //    _iw.addEventListener("open", function () {
            //        _marker.getLabel().hide();
            //    })
            //    _iw.addEventListener("close", function () {
            //        _marker.getLabel().show();
            //    })
            //    label.addEventListener("click", function () {
            //        _marker.openInfoWindow(_iw);
            //    })
            //    if (!!json.isOpen) {
            //        label.hide();
            //        _marker.openInfoWindow(_iw);
            //    }
            //    _marker.openInfoWindow(_iw);
            //})()
        }
    }
    // 复杂的自定义覆盖物
    function ComplexCustomOverlay(point, text, mouseoverText) {
        this._point = point;
        this._text = text;
        if (mouseoverText != undefined) {
            this._overText = mouseoverText;
        }
    }
    //创建覆盖物
    this.addOverLay = function (map,markerArr) {
        ComplexCustomOverlay.prototype = new BMap.Overlay();
        ComplexCustomOverlay.prototype.initialize = function (map) {
            this._map = map;
            var div = this._div = document.createElement("div");
            div.style.zIndex = BMap.Overlay.getZIndex(this._point.lat);

            var arrow = this._arrow = document.createElement("div");
            div.className = "OverlayInsideDiv";
            arrow.style.position = "absolute";
            arrow.style.top = "10px";
            arrow.style.left = "10px";
            arrow.innerHTML = this._text;
            div.appendChild(arrow);

            div.style.backgroundColor = "#313642";
            arrow.style.backgroundPosition = "0px 0px";
            map.getPanes().labelPane.appendChild(div);

            return div;
        }
        ComplexCustomOverlay.prototype.draw = function () {
            var map = this._map;
            var pixel = map.pointToOverlayPixel(this._point);
            this._div.style.left = pixel.x - parseInt(this._arrow.style.left) + "px";
            this._div.style.top = pixel.y - 30 + "px";
        }
        for (var i = 0; i < markerArr.length; i++) {
            var json = markerArr[i];
            var p0 = json.point.split("|")[0];
            var p1 = json.point.split("|")[1];
            var txt = "<b class='iw_poi_title' title='" + json.title + "'>" + json.alarmname + "</b><p><span>" + json.elecname + "</span>" + json.electricity
                + "</p><p><span>" + json.watername + "</span>" + json.water + "</p><p><span>" + json.airname + "</span>" + json.air + "</p>";
            
            var myCompOverlay = new ComplexCustomOverlay(new BMap.Point(p0, p1), txt);
            map.addOverlay(myCompOverlay);
        }
    }
    //初始化(地图容器id，中心点坐标x，y，标注点数组，[地图等级：默认19]）
    this.init = function (id,x, y, level) {
        var _level = level == undefined ? 19 : level;
        map = BaiduMapObj.createMap(id, x, y, _level);
        BaiduMapObj.setMapEvent(map);//设置地图事件
        //BaiduMapObj.setAllView(map);
        BaiduMapObj.addMapControl(map);//向地图添加控件       
        //BaiduMapObj.addMarker(map, markerArr);//向地图中添加marker
        //BaiduMapObj.addOverLay(map, markerArr);//向地图中添加覆盖物
        return map;
    }

    this.clear = function () {
        map.clearOverlays();
    }

    return this;
}).call({});