package com.odts.customTools;

import android.content.Context;
import android.content.Intent;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.odts.activities.R;
import com.odts.activities.RequestDetailActivity;
import com.odts.models.Request;
import com.odts.services.RequestService;

import java.util.List;

public class CancleRequestAdapter extends RecyclerView.Adapter<CancleRequestAdapter.MyViewHolder> {
    private Context context;
    private List<Request> listRequest;

    public class MyViewHolder extends RecyclerView.ViewHolder {
        public TextView rqName, estimes;

        public MyViewHolder(View view) {
            super(view);
            rqName = (TextView) view.findViewById(R.id.txtRequestNameCan);
            estimes = (TextView) view.findViewById(R.id.udDateCan);
            view.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    int position = getAdapterPosition();
                    if (position != RecyclerView.NO_POSITION) {
                        Intent intent = new Intent(context, RequestDetailActivity.class);
                        intent.putExtra("requestID", listRequest.get(position).getRequestId());
                        context.startActivity(intent);
                    }
                }
            });
        }
    }

    public CancleRequestAdapter(Context context, List<Request> listRequest) {
        this.context = context;
        this.listRequest = listRequest;
    }

    @Override
    public CancleRequestAdapter.MyViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View itemView = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.cancel_item, parent, false);

        return new CancleRequestAdapter.MyViewHolder(itemView);
    }

    @Override
    public void onBindViewHolder(final CancleRequestAdapter.MyViewHolder holder, int position) {
        Request album = listRequest.get(position);
        holder.rqName.setText(album.getRequestName());
        holder.estimes.setText("Hủy vào lúc: " + album.getUpdateDate());
    }

    @Override
    public int getItemCount() {
        return listRequest.size();
    }
}
