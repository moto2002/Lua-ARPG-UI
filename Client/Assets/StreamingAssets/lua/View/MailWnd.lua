---
--- Generated by EmmyLua(https://github.com/EmmyLua)
--- Created by Administrator.
--- DateTime: 2018/11/1 12:41
---

MailWnd = {}
local this = MailWnd
local btnReturn;
--构建函数--
function MailWnd.New()
    return this;
end

function MailWnd.Open()
    panelMgr:CreatePanel("UI", 'MailWnd', this.OnCreate);
end

--启动事件--
function MailWnd.OnCreate(obj)
    gameObject = obj;
    transform = obj.transform;

    behavior = transform:GetComponent('LuaBehaviour');
    btnReturn = transform:Find("Title/BtnReturn").gameObject;
    behavior:AddClick(btnReturn,this.OnBtnReturn);
end

-- 返回按钮的点击事件
function MailWnd.OnBtnReturn(go)
    MailWnd.Close();
end

--关闭事件--
function MailWnd.Close()
    panelMgr:ClosePanel(CtrlNames.MailWnd);
end