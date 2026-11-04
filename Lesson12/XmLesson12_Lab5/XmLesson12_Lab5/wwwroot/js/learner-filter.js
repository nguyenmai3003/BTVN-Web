// Lab 5: replace only the learner table when selecting a major in AJAX mode.
$(function () {
    const filter = $("#major-filter");
    if (filter.attr("data-use-ajax") !== "true") {
        return;
    }

    const content = $("#content");
    const status = $("#filter-status");
    const error = $("#filter-error");
    let pendingRequest;

    filter.on("click", "a[data-major-id]", function (event) {
        // Preserve the browser's open-link-in-new-tab behavior.
        if (event.ctrlKey || event.metaKey || event.shiftKey || event.altKey || event.which > 1) {
            return;
        }
        event.preventDefault();

        if (pendingRequest) {
            pendingRequest.abort();
        }

        const link = $(this);
        const majorId = link.attr("data-major-id");
        error.prop("hidden", true);
        content.attr("aria-busy", "true");
        status.text("Loading learner list…");

        pendingRequest = $.ajax({
            url: filter.attr("data-filter-url"),
            type: "GET",
            data: majorId ? { mid: majorId } : {},
            dataType: "html"
        }).done(function (response) {
            content.html(response);
            filter.find("a[data-major-id]").removeClass("active").removeAttr("aria-current");
            link.addClass("active").attr("aria-current", "page");
            status.text("Displayed: " + link.text().trim() + ".");

            // Preserve the selected major when reloading or changing modes.
            window.history.replaceState(null, "", link.attr("href"));
            $("a[data-load-mode]").each(function () {
                const modeLink = new URL(this.href);
                if (majorId) {
                    modeLink.searchParams.set("mid", majorId);
                } else {
                    modeLink.searchParams.delete("mid");
                }
                this.href = modeLink.toString();
            });
        }).fail(function (_, textStatus) {
            if (textStatus !== "abort") {
                status.text("");
                error.text("Unable to load the learner list. Try again or select Reload page mode.")
                    .prop("hidden", false);
            }
        }).always(function () {
            content.attr("aria-busy", "false");
        });
    });
});
