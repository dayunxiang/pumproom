// ajax���ص�����
//# sourceURL=base-BaiduMap.js

//BaiduMapObj �ٶȵ�ͼ��չ--created by zouqj 2017-8-24
var BaiduMapObj = (function () {
    var map = null;
    var iconObj = { w: 21, h: 21, l: 0, t: 0, x: 6, lb: 5 }
    //����һ��Icon
    var createIcon = function (json) {
        var icon = new BMap.Icon("http://map.baidu.com/image/us_mk_icon.png", new BMap.Size(json.w, json.h), { imageOffset: new BMap.Size(-json.l, -json.t), infoWindowOffset: new BMap.Size(json.lb + 5, 1), offset: new BMap.Size(json.x, json.h) })
        return icon;
    }    
    //��������(������
    this.searchMap = function (id, txtWords) {
        var area = document.getElementById(txtWords).value; //�õ�����
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
    //������ͼ������
    this.createMap=function(id,x, y, _level) {
        var map = new BMap.Map(id);//�ڰٶȵ�ͼ�����д���һ����ͼ
        var point = new BMap.Point(x, y);//����һ�����ĵ�����
        map.centerAndZoom(point, _level);//�趨��ͼ�����ĵ�����겢����ͼ��ʾ�ڵ�ͼ������
        return map;
    }
    this.setAllView = function (map) {
        var stCtrl = new BMap.PanoramaControl(); //����ȫ���ؼ�
        stCtrl.setOffset(new BMap.Size(20, 20));
        map.addControl(stCtrl);//���ȫ���ؼ�
        return map;
    }

    //��ͼ�¼����ú�����
    this.setMapEvent = function (map) {
        map.enableDragging();//���õ�ͼ��ק�¼���Ĭ������(�ɲ�д)
        map.enableScrollWheelZoom();//���õ�ͼ���ַŴ���С
        map.enableDoubleClickZoom();//�������˫���Ŵ�Ĭ������(�ɲ�д)
        map.enableKeyboard();//���ü����������Ҽ��ƶ���ͼ
    }
    
    //��ͼ�ؼ���Ӻ�����
    this.addMapControl = function (map) {
        //���ͼ��������ſؼ�
        var ctrl_nav = new BMap.NavigationControl({ anchor: BMAP_ANCHOR_TOP_LEFT, type: BMAP_NAVIGATION_CONTROL_LARGE });
        map.addControl(ctrl_nav);
        //���ͼ���������ͼ�ؼ�
        var ctrl_ove = new BMap.OverviewMapControl({ anchor: BMAP_ANCHOR_BOTTOM_RIGHT, isOpen: 1 });
        map.addControl(ctrl_ove);
        //���ͼ����ӱ����߿ؼ�
        var ctrl_sca = new BMap.ScaleControl({ anchor: BMAP_ANCHOR_BOTTOM_LEFT });
        map.addControl(ctrl_sca);

        var stCtrl = new BMap.PanoramaControl(); //����ȫ���ؼ�
        stCtrl.setOffset(new BMap.Size(20, 20));
        map.addControl(stCtrl);//���ȫ���ؼ�
    }
    
    //����marker
    this.addMarker = function (map,markerArr) {
        for (var i = 0; i < markerArr.length; i++) {
            var json = markerArr[i];
            var p0 = json.point.split("|")[0];
            var p1 = json.point.split("|")[1];
            var point = new BMap.Point(p0, p1);
            //var iconImg = createIcon(icon);
            var marker = new BMap.Marker(point);//����ͼ�� , { icon: iconImg }
            //var iw = createInfoWindow(i);
            var label = new BMap.Label(json.title, { "offset": new BMap.Size(iconObj.lb - iconObj.x + 10, -20) });
            marker.setLabel(label);
            map.addOverlay(marker);
            marker.setAnimation(BMAP_ANIMATION_BOUNCE); //�����Ķ���
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
    // ���ӵ��Զ��帲����
    function ComplexCustomOverlay(point, text, mouseoverText) {
        this._point = point;
        this._text = text;
        if (mouseoverText != undefined) {
            this._overText = mouseoverText;
        }
    }
    //����������
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
    //��ʼ��(��ͼ����id�����ĵ�����x��y����ע�����飬[��ͼ�ȼ���Ĭ��19]��
    this.init = function (id,x, y, level) {
        var _level = level == undefined ? 19 : level;
        map = BaiduMapObj.createMap(id, x, y, _level);
        BaiduMapObj.setMapEvent(map);//���õ�ͼ�¼�
        //BaiduMapObj.setAllView(map);
        BaiduMapObj.addMapControl(map);//���ͼ��ӿؼ�       
        //BaiduMapObj.addMarker(map, markerArr);//���ͼ�����marker
        //BaiduMapObj.addOverLay(map, markerArr);//���ͼ����Ӹ�����
        return map;
    }

    this.clear = function () {
        map.clearOverlays();
    }

    return this;
}).call({});