var path = "http://www.senhaobx.com:890/api/";
$(document).ready(function () {
    var header = '<div class="container mt10">';
    header +='<div class="row">';
    header += '<div class="col-lg-3 col-md-3 col-sm-3 col-xs-8 mt15"><a href="index.html"><img src="MainWeb/images/bd_index_logo.jpg"></a></div>';
    header += '<div class="col-lg-9 col-md-9 col-sm-9 hidden-xs text-right mt20 "><p class="hidden">欢迎您，点此<a href="Login.aspx">登录</a></p><img src="MainWeb/images/bd_index_03.jpg"></div>';
    header += '<div class="col-sm-12 col-xs-4"><nav class="navbar-default zi20"><div class="navbar-header">';
    header += '<button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">';
    header += '<span class="sr-only"></span><span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></button></div><div id="navbar" class="collapse navbar-collapse">';
    header += '<ul class="nav navbar-nav xs_nav1"><li><a href="index.html">首页</a></li>';
    header += '<li role="presentation" class="dropdown" style="position: relative;"><a class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">保险购买</a>';
    header += '<ul class="dropdown-menu xs_nav2">';
    header += '<li role="presentation" class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">团体保险</a>';
    header += '<ul class="dropdown-menu xs_nav3"><li><a href="tourismInsurance.html?TTYWX">意外险</a></li><li><a href="tourismInsurance.html?TTJKX">健康险</a></li><li><a href="tourismInsurance.html?TTSX">寿险</a></li></ul></li>';
    header += '<li role="presentation" class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">个人</a>';
    header += '<ul class="dropdown-menu xs_nav3"><li><a href="tourismInsurance.html?GRYWX">意外险</a></li><li><a href="tourismInsurance.html?GRJKX">健康险</a></li>';
    header += '<li><a href="tourismInsurance.html?GRSX">寿险</a></li><li><a href="tourismInsurance.html?GRZJ">重疾</a></li>';
    header += '<li><a href="tourismInsurance.html?GRFHYL">分红养老</a></li><li><a href="tourismInsurance.html?GRETBX">儿童保险</a></li></ul></li>';
    header += '<li role="presentation" class="dropdown"><a class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">财产</a>';
    header += '<ul class="dropdown-menu xs_nav3"><li><a href="tourismInsurance.html?QYCC">企业财产</a></li><li><a href="tourismInsurance.html?JTCC">家庭财产</a></li>';
    header += '<li><a href="tourismInsurance.html?ZRBX">责任保险</a></li></ul></li>';
    header += '<li><a href="tourismInsurance.html?CL">车辆</a></li>';
    header += '<li role="presentation" class="dropdown"><a href="tourismInsurance.html" class="dropdown-toggle" role="button" aria-haspopup="true" aria-expanded="false">旅游</a>';
    header += '<ul class="dropdown-menu xs_nav3 hidden"><li><a href="tourism_accidentInsurance.html ">旅游意外</a></li><li><a href="tourism_overseasEmergencyRescueInsurance.html">境外紧急救援</a></li></ul></li>';
    header += '<li role="presentation" class="dropdown"><a href="tourismInsurance.html?KX" class="dropdown-toggle" role="button" aria-haspopup="true" aria-expanded="false">卡险</a>';
    header += '<ul class="dropdown-menu xs_nav3 hidden"><li><a href="tourism_accidentInsurance.html "></a></li><li><a href="tourism_overseasEmergencyRescueInsurance.html"></a></li></ul></li>';
    header += '</ul></li><li><a href="claimService.html">理赔服务</a></li><li><a href="talentRecruitment.html">人才招聘</a></li><li><a href="aboutus.html?GSJJ">关于我们</a></li></ul></div></nav></div></div></div>';
    $("header").html(header);
    $("footer").html('<div style="background: #f7f7f7;"><div class="container"><p style="color:#34a86b; font-size:18px; padding-top:15px;"><strong>合作机构</strong></p><div class="row"><div class="col-xs-2"><a href=""><img src="MainWeb/images/lj_1.jpg" class="img-responsive" /></a></div><div class="col-xs-2"><a href=""><img src="MainWeb/images/lj_2.jpg" class="img-responsive" /></a></div><div class="col-xs-2"><a href=""><img src="MainWeb/images/lj_3.jpg" class="img-responsive" /></a></div><div class="col-xs-2"><a href=""><img src="MainWeb/images/lj_4.jpg" class="img-responsive" /></a></div><div class="col-xs-2"><a href=""><img src="MainWeb/images/lj_5.jpg" class="img-responsive" /></a></div><div class="col-xs-2"><a href=""><img src="MainWeb/images/lj_6.jpg" class="img-responsive" /></a></div></div><div class="row"><div class="col-xs-2"><a href=""><img src="MainWeb/images/lj_7.jpg" class="img-responsive" /></a></div><div class="col-xs-2"><a href=""><img src="MainWeb/images/lj_8.jpg" class="img-responsive" /></a></div><div class="col-xs-2"><a href=""><img src="MainWeb/images/lj_9.jpg" class="img-responsive" /></a></div><div class="col-xs-2"><a href=""><img src="MainWeb/images/lj_10.jpg" class="img-responsive" /></a></div><div class="col-xs-2"><a href=""><img src="MainWeb/images/lj_11.jpg" class="img-responsive" /></a></div><div class="col-xs-2"><a href=""><img src="MainWeb/images/lj_12.jpg" class="img-responsive" /></a></div></div><div class="row"><div class="col-xs-2"><a href=""><img src="MainWeb/images/lj_13.jpg" class="img-responsive" /></a></div><div class="col-xs-2"><a href=""><img src="MainWeb/images/lj_14.jpg" class="img-responsive" /></a></div><div class="col-xs-2"><a href=""><img src="MainWeb/images/lj_15.jpg" class="img-responsive" /></a></div><div class="col-xs-2"><a href=""><img src="MainWeb/images/lj_16.jpg" class="img-responsive" /></a></div><div class="col-xs-2"><a href=""><img src="MainWeb/images/lj_17.jpg" class="img-responsive" /></a></div><div class="col-xs-2"><a href=""><img src="MainWeb/images/lj_18.jpg" class="img-responsive" /></a></div><div class="col-xs-2"><a href=""><img src="MainWeb/images/lj_19.jpg" class="img-responsive" /></a></div></div></div></div><div style="background: #34a86b;padding: 30px;"><div class="container" style="color: #fff;"><div class="row"><div class="col-lg-6 col-md-6 col-sm-6 col-xs-6"><a href="aboutus.html?GSJJ">关于我们</a>|<a href="helpList.html?WT">常见问题</a>|<a href="">联系我们</a></div><div class="col-lg-6 col-md-6 col-sm-6 col-xs-6"><p style="color: #fff;">Copyright © 上海森昊保险代理有限公司 版权所有 <a style="margin:0px;" href="Http://www.miitbeian.gov.cn" target="_blank">沪ICP备：16005694号</a></p></div></div></div></div>');
    dropdownOpen();//调用
});
//导航悬浮显示
/**
 * 鼠标划过就展开子菜单，免得需要点击才能展开
 */
function dropdownOpen() {

    var $dropdownLi = $('li.dropdown');

    $dropdownLi.mouseover(function () {
        $(this).addClass('open');
    }).mouseout(function () {
        $(this).removeClass('open');
    });
}