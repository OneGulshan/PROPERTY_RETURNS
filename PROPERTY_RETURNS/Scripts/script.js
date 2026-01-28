
$('#txtProposedDate').change(function () {
    $('#lblReviewProposedDate').html("<span class='bold'>Proposed Date of Inspection : </span>" + $("#txtProposedDate").val());
});
$('#txtNoOfDays').change(function () {
    $('#lblReviewDaysRequired').html("<span class='bold'>No. of Days Required : </span>" + $("#txtNoOfDays").val());
});
$('#ddlWeeklyOffDay').change(function () {
    $('#lblReviewWeeklyOff').html("<span class='bold'>Weekly Off Day : </span>" + $("#ddlWeeklyOffDay option:selected").text());
});
function inspectionUnderTaking() {
    $("#tab2").addClass("active");
    $("#tab1").removeClass("active");
    $("#tab3").removeClass("active");
    $("#tab4").removeClass("active");
    $("#undertakingTab").removeClass("active");
    $("#basicInfoTab").addClass("active");
    $("#itemsTab").removeClass("active");
    $("#reviewTab").removeClass("active");
}

function inspectionBasicInfo() {
    $("#tab3").addClass("active");
    $("#tab1").removeClass("active");
    $("#tab2").removeClass("active");
    $("#tab4").removeClass("active");
    $("#undertakingTab").removeClass("active");
    $("#basicInfoTab").removeClass("active");
    $("#itemsTab").addClass("active");
    $("#reviewTab").removeClass("active");
}

function inspectionItems() {
    $("#tab3").removeClass("active");
    $("#tab1").removeClass("active");
    $("#tab2").removeClass("active");
    $("#tab4").addClass("active");
    $("#undertakingTab").removeClass("active");
    $("#basicInfoTab").removeClass("active");
    $("#itemsTab").removeClass("active");
    $("#reviewTab").addClass("active");
}

$('#nextTab').click(function () {
    $('#navTab').find('.active').next().children().trigger('click');
});

$('#prevTab').click(function () {
    $('#navTab').find('.active').prev().children().trigger('click');
});


$('#tab2Next').click(function () {
    $('#navTab').find('.active').next().children().trigger('click');
});
$('#tab3Prev').click(function () {
    $('#navTab').find('.active').prev().children().trigger('click');
});
$('#tab3Next').click(function () {
    $('#navTab').find('.active').next().children().trigger('click');
});
$('#tab4Prev').click(function () {
    $('#navTab').find('.active').prev().children().trigger('click');
});

function allUndertakingsChecked() {
//    var all_checkboxes = $('#tab1 input[type="checkbox"]');

//    if (all_checkboxes.length === all_checkboxes.filter(":checked").length) {
//        inspectionUnderTaking();
//    }
//    else {
//        $.gritter.add({
//            title: 'Error',
//            text: 'Please check all undertakings before proceed.',
    //            class_name: 'growl-danger gritter-center',
//            sticky: false,
//            time: ''
//        });
//        return false;
//       }
    inspectionUnderTaking();
}

function showInspectionSuccessMessage(inspCallNumber) {
    $.gritter.add({
        title: 'Success',
        text: 'Your inspection call has been raised succesfully. Please note down your inspection call number ' + inspCallNumber,
        class_name: 'growl-success gritter-center', 
        sticky: false,
        time: '4000',
        after_close: function () {
            setTimeout($(location).attr('href', '../Inspection/inspectioncall.aspx'), 100000);
        }
    });  
    return false;
}

function showCHPSuccess(chpNumber) {
    $.gritter.add({
        title: 'Success',
        text: 'Your CHP has been generated succesfully with CHP number ' + chpNumber,
        class_name: 'growl-success gritter-center',
        sticky: false,
        time: '4000',
        after_close: function () {
            setTimeout($(location).attr('href', '../Inspection/GenerateCHP.aspx'), 100000);
        }
    });
    return false;
}

function showQtyErrorMessage(allowedQty) {
    $.gritter.add({
        title: 'Error',
        text: 'The input quantity cananot be greater than ' + allowedQty,
        class_name: 'growl-danger gritter-center',
        sticky: false,
        time: '4000'
    });
    return false;
}

function showMDCCGenerationFailed() {
    $.gritter.add({
        title: 'Error',
        text: 'The MDCC generation has been failed please try again.',
        class_name: 'growl-danger gritter-center',
        sticky: false,
        time: '4000',
        after_close: function () {
            setTimeout($(location).attr('href', '../Inspection/GenerateMDCC.aspx'), 100000);
        }
    });
    return false;
}
function showMDCCGenerationSuccess(mdccNumber) {
    $.gritter.add({
        title: 'Success',
        text: 'The MDCC generation has been succesful. The MDCC Number is : ' + mdccNumber,
        class_name: 'growl-success gritter-center',
        sticky: false,
        time: '4000',
        after_close: function () {
            setTimeout($(location).attr('href', '../Inspection/GenerateMDCC.aspx'), 100000);
        }
    });
    return false;
}

function showInspectionApprovalSuccess(inspNumber) {
    $.gritter.add({
        title: 'Success',
        text: 'The Inspection with Inspection Number : ' + inspNumber + ' has been approved successfully.',
        class_name: 'growl-success gritter-center',
        sticky: false,
        time: '4000',
        after_close: function () {
            setTimeout($(location).attr('href', '../Inspection/InspectionCall.aspx'), 100000);
        }
    });
    return false;
}

function showInspectionRejectionSuccess(inspNumber) {
    $.gritter.add({
        title: 'Success',
        text: 'The Inspection with Inspection Number : ' + inspNumber + ' has been rejected successfully.',
        class_name: 'growl-success gritter-center',
        sticky: false,
        time: '4000',
        after_close: function () {
            setTimeout($(location).attr('href', '../Inspection/InspectionCall.aspx'), 100000);
        }
    });
    return false;
}

function showMDCCConfirmationMessage() {
    var n = $("input:checked").length;
    if (confirm("Are you sure to create a new MDCC  \n with " + n + " no(s). of material(s) selected by you.\n \n (This process can not be undone.)")) {
        return true;
    } else {
        return false;
    }
}

function showInspGridSuccess() {
    $.gritter.add({
        title: 'Success',
        text: 'The inspection grid has been created successfully.',
        class_name: 'growl-success gritter-center',
        sticky: false,
        time: '4000',
        after_close: function () {
            setTimeout($(location).attr('href', '../Inspection/InspectionGrid.aspx'), 100000);
        }
    });
    return false;
}

function showInspGridAlreadyCreatedMessage(gridStartDate) {
    $.gritter.add({
        title: 'Success',
        text: 'The Inspection grid with start date "' + gridStartDate + '" has been already created. Please view/edit the grid from Inspection Grid List.',
        class_name: 'growl-danger gritter-center',
        sticky: false,
        time: '4000'
    });
    return false;
}


function showFileUploadSuccess(fileName) {
    $.gritter.add({
        title: 'Success',
        text: 'The document with name "' + fileName + '" has been uploaded successfully.',
        class_name: 'growl-success gritter-center',
        sticky: false,
        time: '4000',
        after_close: function () {
            setTimeout($(location).attr('href', '../Inspection/UploadReport.aspx'), 10000);
        }
    });
    return false;
}

function showFileUploadFailure(fileName) {
    $.gritter.add({
        title: 'Error',
        text: 'The document with name "' + fileName + '" has not been uploaded due to some error.',
        class_name: 'growl-danger gritter-center',
        sticky: false,
        time: '4000'
    });
    return false;
}

function showSuccess() {
    $.gritter.add({
        title: 'Success',
        text: 'Data has been saved successfully.',
        class_name: 'growl-success gritter-center',
        sticky: false,
        time: '4000'
    });
    return false;
}


 // scroll to element animation
 function scrollTo(id) {
     if ($(id).length)
         $('html,body').animate({ scrollTop: $(id).offset().top }, 'slow');
 }

 // handle menu toggle button action
 function toggleMenuHidden() {
     $('.container-fluid:first').toggleClass('menu-hidden');
     
 }


 $(function () {
     // Sidebar menu collapsibles
     $('#menu .collapse').on('show', function (e) {
         e.stopPropagation();
         $(this).parents('.hasSubmenu:first').addClass('active');
     })
	.on('hidden', function (e) {
	    e.stopPropagation();
	    $(this).parents('.hasSubmenu:first').removeClass('active');
	});
	$(".select").select2({
	    minimumResultsForSearch: 10
	});
     // main menu visibility toggle
     $('.navbar.main .btn-navbar').click(function () {
         var disabled = typeof toggleMenuButtonWhileTourOpen != 'undefined' ? toggleMenuButtonWhileTourOpen(true) : false;
         if (!disabled)
             toggleMenuHidden();
     });
     $('.hasSubmenu').on('click', function (e) {
         e.stopPropagation();
         $(this).children('ul').toggle('in'); ;
     })

     // multi-level top menu
     $('.submenu').hover(function () {
         $(this).children('ul').removeClass('submenu-hide').addClass('submenu-show');
     }, function () {
         $(this).children('ul').removeClass('.submenu-show').addClass('submenu-hide');
     })
    .find("a:first").append(" &raquo; ");



     // trigger window resize event
     $(window).resize();


     // menu slim scroll max height
     setTimeout(function () {
         var menu_max_height = parseInt($('#menu .slim-scroll').attr('data-scroll-height'));
         var menu_real_max_height = parseInt($('#wrapper').height());
         $('#menu .slim-scroll').slimScroll({
             height: (menu_max_height < menu_real_max_height ? (menu_real_max_height - 20) : menu_max_height) + "px",
             allowPageScroll: true,
             railVisible: false,
             color: 'transparent',
             railDraggable: ($.fn.draggable ? true : false)
         });

         // fixes weird bug when page loads and mouse over the sidebar (can't scroll)
         $('#menu .slim-scroll').trigger('mouseenter').trigger('mouseleave');
     }, 200);

     /* Slim Scroll Widgets */
     $('.widget-scroll').each(function () {
         $(this).find('.widget-body > div').slimScroll({
             height: $(this).attr('data-scroll-height')
         });
     });

     /* Other non-widget Slim Scroll areas */
     $('#content .slim-scroll').each(function () {
         $(this).slimScroll({
             height: $(this).attr('data-scroll-height'),
             allowPageScroll: false,
             railDraggable: ($.fn.draggable ? true : false)
         });
     });

    
     /*
     * Boostrap Extended
     */
     // custom select for Boostrap using dropdowns
     if ($('.selectpicker').length) $('.selectpicker').selectpicker();

     // bootstrap-toggle-buttons
     if ($('.toggle-button').length) $('.toggle-button').toggleButtons();

     /*
     * UniformJS: Sexy form elements
     */
     if ($('.uniformjs').length) $('.uniformjs').find("select, input, button, textarea").uniform();

     // colorpicker
     if ($('#colorpicker').length) $('#colorpicker').farbtastic('#colorpickerColor');

     // datepicker
     if ($('#datepicker').length) $("#datepicker").datepicker({ showOtherMonths: true });
     if ($('#datepicker-inline').length) $('#datepicker-inline').datepicker({ inline: true, showOtherMonths: true });

     // daterange
     if ($('#dateRangeFrom').length && $('#dateRangeTo').length) {
         $("#dateRangeFrom").datepicker({
             defaultDate: "+1w",
             changeMonth: false,
             numberOfMonths: 2,
             onClose: function (selectedDate) {
                 $("#dateRangeTo").datepicker("option", "minDate", selectedDate);
             }
         }).datepicker("option", "maxDate", $('#dateRangeTo').val());

         $("#dateRangeTo").datepicker({
             defaultDate: "+1w",
             changeMonth: false,
             numberOfMonths: 2,
             onClose: function (selectedDate) {
                 $("#dateRangeFrom").datepicker("option", "maxDate", selectedDate);
             }
         }).datepicker("option", "minDate", $('#dateRangeFrom').val());
     }

     /* Table select / checkboxes utility */
     $('.checkboxs thead :checkbox').change(function () {
         if ($(this).is(':checked')) {
             $('.checkboxs tbody :checkbox').prop('checked', true).parent().addClass('checked');
             $('.checkboxs tbody tr.selectable').addClass('selected');
             $('.checkboxs_actions').show();
         }
         else {
             $('.checkboxs tbody :checkbox').prop('checked', false).parent().removeClass('checked');
             $('.checkboxs tbody tr.selectable').removeClass('selected');
             $('.checkboxs_actions').hide();
         }
     });

     $('.checkboxs tbody').on('click', 'tr.selectable', function (e) {
         var c = $(this).find(':checkbox');
         var s = $(e.srcElement);

         if (e.srcElement.nodeName == 'INPUT') {
             if (c.is(':checked'))
                 $(this).addClass('selected');
             else
                 $(this).removeClass('selected');
         }
         else if (e.srcElement.nodeName != 'TD' && e.srcElement.nodeName != 'TR' && e.srcElement.nodeName != 'DIV') {
             return true;
         }
         else {
             if (c.is(':checked')) {
                 c.prop('checked', false).parent().removeClass('checked');
                 $(this).removeClass('selected');
             }
             else {
                 c.prop('checked', true).parent().addClass('checked');
                 $(this).addClass('selected');
             }
         }
         if ($('.checkboxs tr.selectable :checked').size() == $('.checkboxs tr.selectable :checkbox').size())
             $('.checkboxs thead :checkbox').prop('checked', true).parent().addClass('checked');
         else
             $('.checkboxs thead :checkbox').prop('checked', false).parent().removeClass('checked');

         if ($('.checkboxs tr.selectable :checked').size() >= 1)
             $('.checkboxs_actions').show();
         else
             $('.checkboxs_actions').hide();
     });

     if ($('.checkboxs tbody :checked').size() == $('.checkboxs tbody :checkbox').size() && $('.checkboxs tbody :checked').length)
         $('.checkboxs thead :checkbox').prop('checked', true).parent().addClass('checked');

     if ($('.checkboxs tbody :checked').length)
         $('.checkboxs_actions').show();

     $('.radioboxs tbody tr.selectable').click(function (e) {
         var c = $(this).find(':radio');
         if (e.srcElement.nodeName == 'INPUT') {
             if (c.is(':checked'))
                 $(this).addClass('selected');
             else
                 $(this).removeClass('selected');
         }
         else if (e.srcElement.nodeName != 'TD' && e.srcElement.nodeName != 'TR') {
             return true;
         }
         else {
             if (c.is(':checked')) {
                 c.attr('checked', false);
                 $(this).removeClass('selected');
             }
             else {
                 c.attr('checked', true);
                 $('.radioboxs tbody tr.selectable').removeClass('selected');
                 $(this).addClass('selected');
             }
         }
     });

     // sortable tables
     if ($(".js-table-sortable").length) {
         $(".js-table-sortable").sortable(
		{
		    placeholder: "ui-state-highlight",
		    items: "tbody tr",
		    handle: ".js-sortable-handle",
		    forcePlaceholderSize: true,
		    helper: function (e, ui) {
		        ui.children().each(function () {
		            $(this).width($(this).width());
		        });
		        return ui;
		    },
		    start: function (event, ui) {
		        if (typeof mainYScroller != 'undefined') mainYScroller.disable();
		        ui.placeholder.html('<td colspan="' + $(this).find('tbody tr:first td').size() + '">&nbsp;</td>');
		    },
		    stop: function () { if (typeof mainYScroller != 'undefined') mainYScroller.enable(); }
		});
     }
 });