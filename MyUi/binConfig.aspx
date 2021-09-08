<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="binConfig.aspx.cs" Inherits="MyUi.WebForm1" %>
<!DOCTYPE html>
<html>
<head runat="server">
  <meta charset="utf-8">
  <title>料仓配置界面</title>
  <meta name="renderer" content="webkit">
  <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
  <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
  <link rel="stylesheet" href="css/layui.css"  media="all">
  <!-- 注意：如果你直接复制所有代码到本地，上述css路径需要改成你本地的 -->

</head>
<body runat="server">

<fieldset class="layui-elem-field layui-field-title" style="margin-top: 20px;">
  <legend>料仓信息</legend>
</fieldset>

  <table class="layui-hide" id="binInfo" lay-filter="binInfo"></table>

<fieldset class="layui-elem-field layui-field-title" style="margin-top: 20px;">
  <legend>配置料仓</legend>
</fieldset>
 
<form class="layui-form" onsubmit="return false" runat="server" action="">
  <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>  
  
  <div class="layui-form-item">
    <label class="layui-form-label">料仓1</label>
    <div class="layui-input-block">
      <select name="bin1" id="bin1"  lay-filter="bin1">
        <option value="">请选择物料</option>
      </select>
    </div>
  </div>

  <div class="layui-form-item">
    <label class="layui-form-label">料仓2</label>
    <div class="layui-input-block">
      <select name="bin2" id="bin2"  lay-filter="bin2">
        <option value="">请选择物料</option>
      </select>
    </div>
  </div>

  <div class="layui-form-item">
    <label class="layui-form-label">料仓3</label>
    <div class="layui-input-block">
      <select name="bin3" id="bin3"  lay-filter="bin3">
        <option value="">请选择物料</option>
      </select>
    </div>
  </div>

  <div class="layui-form-item">
    <label class="layui-form-label">料仓4</label>
    <div class="layui-input-block">
      <select name="bin4" id="bin4" lay-filter="bin4">
        <option value="">请选择物料</option>
      </select>
    </div>
  </div>

  <div class="layui-form-item">
    <label class="layui-form-label">料仓5</label>
    <div class="layui-input-block">
      <select name="bin5" id="bin5" lay-filter="bin5">
        <option value="">请选择物料</option>
      </select>
    </div>
  </div>

  <div class="layui-form-item">
    <label class="layui-form-label">料仓6</label>
    <div class="layui-input-block">
      <select name="bin6" id="bin6" lay-filter="bin6">
        <option value="">请选择物料</option>
      </select>
    </div>
  </div>
  
  
  <div class="layui-form-item">
    <div class="layui-input-block">
      <button  type="submit" class="layui-btn" lay-submit="" lay-filter="submitOrder">立即提交</button>
       <button id="defalut"  class="layui-btn">初始化配置</button>
      <button type="reset" class="layui-btn layui-btn-primary">重置</button>
    </div>
  </div>
  
</form>
 

<script src="JQurey3.5.1.js" charset="utf-8"></script>          
<script src="layui.all.js" charset="utf-8"></script>
<!-- 注意：如果你直接复制所有代码到本地，上述js路径需要改成你本地的 -->
<script  type="text/javascript" language="javascript">


    layui.use(['form', 'table'], function(){
      var form = layui.form
        , layer = layui.layer
        , table = layui.table;

        var adminTable = table.render({
            elem: '#binInfo'
            , url: `http://localhost:56912/api/bins`
            , parseData: function (res) { //res 即为原始返回的数据
                return {
                    "code": 0, //解析接口状态
                    "msg": '', //解析提示文本
                    "count": res.length, //解析数据长度
                    "data": res //解析数据列表
                };
            }
            , title: '料仓信息表'
            , cols: [[
                { type: 'numbers', fixed: 'left' }
                , { field: 'id', title: '料仓编号', width: 400, fixed: 'left', unresize: true, sort: true }
                , { field: 'binMaterialId', title: '物料编号', width: 400, edit: 'text' }
                , { field: 'binType', title: '物料类型', width: 400, edit: 'text' }
            ]]
        });


        $.ajax({

            type: "GET",
            url: 'http://localhost:56912/api/materials/Getmaterials',
            success: (res) => {
                var materialData = res;
                var materialType1 = [];
                var materialType2 = [];
                for (item in res) {
                    if (res[item].materialType === 1) {
                        materialType1.push(res[item]);
                    }
                    else if (res[item].materialType === 2) {
                        materialType2.push(res[item]);
                    };
                };
            
                //console.log(materialData);
                //console.log(materialType1);
                //console.log(materialType2);

                $.ajax({
                    type: "GET",
                    url: 'http://localhost:56912/api/bins',
                    success: (res) => {
                        for (let i = 0; i < 6; i++) {

                            if (res[i].binType == 0) {

                                for (item in materialData) {
                                    $(`#bin${i + 1}`).append(`<option value="${materialData[item].id}" class="${materialData[item].id}" type="${materialData[item].materialType}">${materialData[item].materialName}</option>`);

                                }
                            }

                            else if (res[i].binType == 1) {
                                for (item in materialType1) {
                                    $(`#bin${i + 1}`).append(`<option value="${materialType1[item].id}" class="${materialData[item].id}">${materialType1[item].materialName}</option>`);
                                }
                            }

                            else if (res[i].binType == 2) {
                                for (item in materialType2) {
                                    $(`#bin${i + 1}`).append(`<option value="${materialType2[item].id}" class="${materialData[item].id}">${materialType2[item].materialName}</option>`);
                                }
                            }
                            else {
                                $(`#bin${i + 1}`).append(`<option value="">请选择材料</option>`)
                            };

                        };
                        layui.form.render("select");

                    },
                    error: (res) => {
                        layui.layer.alert('获取料仓信息失败');
                    }

                })

            },
            error: (res) => {
                layui.layer.alert('获取物料信息失败');
            }

        
        });


         form.on('submit(submitOrder)', function(data){
            configData = data.field;
             var info = '';
             for (let i = 1; i < 7;i++)
            {
              var sendData={}; 
                sendData.binMaterialId = parseInt(configData[`bin${i}`]);
                info += sendData.binMaterialId;
              if(sendData.binMaterialId<5)
              {
                sendData.binType = 1;
              }
              else if (sendData.binMaterialId>4)
              {
                sendData.binType = 2;
              };
              sendData.id = i;
              // console.log(j);
              // console.log(typeof(sendData.binMaterialId));
              // console.log(typeof(sendData.binType));
              // console.log(typeof(sendData.id));
              sendData = JSON.stringify(sendData);
              $.ajax({
                type:"PUT",
                url:`http://localhost:56912/api/bins/${i}`,
                data:sendData,
                contentType:"application/json",
                success:()=>{
                    //layui.layer.open({
                    //    title: '通知',
                    //    content: '配置成功',
                    //    btn: ['确认'],
                    //    yes: function () {
                    //        window.location.href = "binConfig.aspx"
                    //    }
                    //})
                },
                error:()=>{
                  layer.alert('配置失败')
                  }

              });
          
                
            }
            
          adminTable.reload();

          //console.log(info);

          PageMethods.writeBin(info);

          // layui.layer.open({
          //         title: '通知',
          //         content: '配置成功',
          //         btn: ['确认'],
                  
          //   })
             
            
         });

        $("#defalut").click(function () {
            
                layui.layer.open({
                    title: '提醒',
                    content: '确定要重置为初始化料仓配置吗？',
                    btn: ['确认'],
                    yes: function () {
                        PageMethods.clearSet();
                        for (let i = 1; i < 7; i++) {
                            //console.log(i);
                            resetData = {
                                "id": i,
                                "binMaterialId": 0,
                                "binType": 0
                            };
                            resetData = JSON.stringify(resetData);
                            //console.log(resetData);
                            $.ajax({
                                type: "PUT",
                                url: `http://localhost:56912/api/bins/${i}`,
                                data: resetData,
                                contentType: "application/json",
                                success: () => {
                                    layui.layer.open({
                                        title: '通知',
                                        content: '初始化成功',
                                        btn: ['确认'],
                                        yes: function () {
                                            window.location.href = "binConfig.aspx"
                                        }
                                    })

                                },
                                error: () => {
                                    layer.alert('配置失败')
                                }

                            });
                        }
                    }
                })

            
        });
       
  
    });

   



</script>

</body>
</html>