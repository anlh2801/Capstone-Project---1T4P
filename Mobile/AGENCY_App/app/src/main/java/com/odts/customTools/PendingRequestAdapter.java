package com.odts.customTools;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.support.annotation.NonNull;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageButton;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.odts.models.Request;
import com.odts.models.RequestGroupMonth;
import com.odts.activities.R;
import com.odts.services.RequestService;
import com.odts.utils.Enums;

import java.util.List;


public class PendingRequestAdapter extends ArrayAdapter<RequestGroupMonth> {
    Activity context;
    int resource;
    List<RequestGroupMonth> objects;
    ImageButton btnCancelRequest;
    RequestService requestService;
    private List<Request> listRequest;
    int requestID = 0;
    public PendingRequestAdapter(@NonNull Activity context, int resource, @NonNull List<RequestGroupMonth> objects) {
        super(context, resource, objects);
        this.context = context;
        this.resource = resource;
        this.objects = objects;
    }
    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        LayoutInflater inflater = this.context.getLayoutInflater();
        View row = inflater.inflate(this.resource, null);
        TextView txtThangNam = (TextView) row.findViewById(R.id.txtThangNam);
        LinearLayout lvDetailsThangNam = (LinearLayout) row.findViewById(R.id.detailsRequestGroup);
        final RequestGroupMonth requestGroupMonth = this.objects.get(position);
        txtThangNam.setText(requestGroupMonth.getMonthYearGroup());

        for (final Request item: requestGroupMonth.getRequestOfITSupporter()) {
            View view = inflater.inflate(R.layout.pending_item, null);
            TextView txtRequestName = (TextView) view.findViewById(R.id.txtRequestNamee);
            TextView txtEndDate = (TextView) view.findViewById(R.id.txtNoD);
            TextView txtCreateDate = (TextView) view.findViewById(R.id.txtCreateDatee);
            txtRequestName.setText(item.getAgencyName() + " - " + item.getRequestName());
            txtCreateDate.setText("Tạo vào: " + item.getCreateDate());
            txtEndDate.setText("Thiết bị cần xử lý: " + item.getNod());
            btnCancelRequest = (ImageButton) view.findViewById(R.id.btnCancelRequest);
            requestService = new RequestService();
            btnCancelRequest.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(final View view) {
                    AlertDialog.Builder builder = new AlertDialog.Builder(context);
                    builder
                            .setMessage("Bạn chắc chắn muốn hủy không?")
                            .setPositiveButton("Có", new DialogInterface.OnClickListener() {
                                @Override
                                public void onClick(DialogInterface dialog, int id) {
                                    requestService.cancelTicket(context, item.getRequestId(), Enums.RequestStatusEnum.Cancel.getIntValue());
//                                listRequest.remove(getAdapterPosition());
//                                notifyItemRemoved(getAdapterPosition());
//                                    notifyItemRangeRemoved(getAdapterPosition(), listRequest.size());
                                }
                            })
                            .setNegativeButton("Không", new DialogInterface.OnClickListener() {
                                @Override
                                public void onClick(DialogInterface dialog, int id) {
                                    dialog.cancel();
                                }
                            })
                            .show();
                }
            });
            lvDetailsThangNam.addView(view);
        }


        return row;
    }
}
