function getSelectionParentElement() {
    var parentEl = null, sel;
    if (window.getSelection) {
        sel = window.getSelection();
        if (sel.rangeCount) {
            parentEl = sel.getRangeAt(0).commonAncestorContainer;
            if (parentEl.nodeType != 1) {
                parentEl = parentEl.parentNode;
            }
        }
    } else if ((sel = document.selection) && sel.type != "Control") {
        parentEl = sel.createRange().parentElement();
    }
    return parentEl;
}

window.onmouseup = event => {
    let selection = document.getSelection();
    let selectedText = selection.toString();
    if (selectedText.trim() != '') {
        let parentEl = getSelectionParentElement();
        while (!parentEl.hasAttribute("data-mid")) {
            parentEl = parentEl.parentNode;
        }
        var mid = parentEl.getAttribute("data-mid");
        if (confirm('Сохранить в пул сообщение с id ' + mid + '?')) {
            let jsonObject =
            {
                tlgMessageId : mid
            };
            window.chrome.webview.postMessage(jsonObject);
        } else {
        }
    }
};