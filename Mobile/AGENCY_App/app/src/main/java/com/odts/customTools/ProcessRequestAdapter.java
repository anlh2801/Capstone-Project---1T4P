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

public class ProcessRequestAdapter extends RecyclerView.Adapter<ProcessRequestAdapter.MyViewHolder> {
    private Context context;
    private List<Request> listRequest;
    RequestService requestService;

    public class MyViewHolder extends RecyclerView.ViewHolder {
        public TextView rqName, estimes, nod, hero;
        public MyViewHolder(View view) {
            super(view);
            rqName = (TextView) view.findViewById(R.id.txtRequestNamePro);
            nod = (TextView) view.findViewById(R.id.txtNoDPro);
            hero = (TextView) view.findViewById(R.id.txtHero);
            estimes = (TextView) view.findViewById(R.id.estimatesTime);


            view.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    int position = getAdapterPosition();
                    if(position != RecyclerView.NO_POSITION) {
                        Intent intent = new Intent(context, RequestDetailActivity.class);
                        intent.putExtra("requestID", listRequest.get(position).getRequestId());
                        context.startActivity(intent);
                    }
                }
            });
        }
    }
    public ProcessRequestAdapter(Context context, List<Request> listRequest) {
        this.context = context;
        this.listRequest = listRequest;
    }
    @Override
    public ProcessRequestAdapter.MyViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View itemView = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.process_item, parent, false);

        return new ProcessRequestAdapter.MyViewHolder(itemView);
    }
    @Override
    public void onBindViewHolder(final ProcessRequestAdapter.MyViewHolder holder, int position) {
        Request album = listRequest.get(position);
        holder.rqName.setText(album.getRequestName());
        holder.nod.setText("Thiết bị cần xử lý: "+album.getNod());
        holder.hero.setText("ĐƯợc xử lý bởi: "+ album.getTicket().get(0).getiTSupporterName());
        holder.estimes.setText("Dự kiến hoàn thành: " +album.getTicket().get(0).getTicketEstimationTime());
    }

    @Override
    public int getItemCount() {
        return listRequest.size();
    }
}
