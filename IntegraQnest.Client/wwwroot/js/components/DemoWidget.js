import React from 'react';
export default function DemoWidget() {
    return (React.createElement("div", { style: { padding: "10px", border: "1px solid #aaa" } },
        React.createElement("h4", null, "\uD83D\uDD37 React + TypeScript Demo"),
        React.createElement("p", null, "This widget is rendered by React inside a Blazor page.")));
}
