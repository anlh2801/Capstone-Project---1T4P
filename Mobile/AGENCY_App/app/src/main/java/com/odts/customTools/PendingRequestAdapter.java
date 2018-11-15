package com.odts.customTools;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageButton;
import android.widget.TextView;
import android.widget.Toast;

import com.odts.activities.R;
import com.odts.activities.RequestDetailActivity;
import com.odts.models.Request;
import com.odts.services.RequestService;
import com.odts.utils.Enums;

import java.util.List;

public class PendingRequestAdapter extends RecyclerView.Adapter<PendingRequestAdapter.MyViewHolder> {
    private Context context;
    private List<Request> listRequest;
    RequestService requestService;

    public PendingRequestAdapter() {
        requestService = new RequestService();
    }

    public class MyViewHolder extends RecyclerView.ViewHolder {
        public TextView rqName, crDate, nod;
        public ImageButton btnCancelRequest;
        public int requestId = 0;

        public MyViewHolder(View view) {
            super(view);
            requestService = new RequestService();
            rqName = (TextView) view.findViewById(R.id.txtRequestNamee);
            crDate = (TextView) view.findViewById(R.id.txtCreateDatee);
            nod = (TextView) view.findViewById(R.id.txtNoD);
            btnCancelRequest = (ImageButton) view.findViewById(R.id.btnCancelRequest);
            btnCancelRequest.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(final View view) {
                    AlertDialog.Builder builder = new AlertDialog.Builder(context);
                    builder
                            .setMessage("Bạn chắc chắn muốn hủy không?")
                            .setPositiveButton("Có", new DialogInterface.OnClickListener() {
                                @Override
                                public void onClick(DialogInterface dialog, int id) {
                                    requestService.cancelTicket(context, requestId, Enums.RequestStatusEnum.Cancel.getIntValue());
                                    listRequest.remove(getAdapterPosition());
                                    notifyItemRemoved(getAdapterPosition());
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
//            rqNameDT = (TextView) view.findViewById(R.id.requestNameDetail);
//            view.setOnClickListener(new View.OnClickListener() {
//                @Override
//                public void onClick(View view) {
//                    int position = getAdapterPosition();
//                    if(position != RecyclerView.NO_POSITION) {
//                        Intent intent = new Intent(context, RequestDetailActivity.class);
//                        intent.putExtra("requestID", listRequest.get(position).getRequestId());
//                        context.startActivity(intent);
//                    }
//                }
//            });
        }
    }

    public PendingRequestAdapter(Context context, List<Request> listRequest) {
        this.context = context;
        this.listRequest = listRequest;
    }

    @Override
    public MyViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View itemView = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.activity_list_item, parent, false);

        return new MyViewHolder(itemView);
    }

    @Override
    public void onBindViewHolder(final MyViewHolder holder, int position) {
        Request album = listRequest.get(position);
        holder.rqName.setText(album.getRequestName());
        holder.crDate.setText("Tạo vào: " + album.getCreateDate());
        holder.nod.setText("Thiết bị cần xử lý: " + album.getNod());
        holder.requestId = album.getRequestId();
//        holder.rqNameDT.setText(album.getCreateDate());

    }

    @Override
    public int getItemCount() {
        return listRequest.size();
    }

}
