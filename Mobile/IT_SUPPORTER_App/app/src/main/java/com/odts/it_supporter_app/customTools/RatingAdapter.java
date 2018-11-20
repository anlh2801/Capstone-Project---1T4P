package com.odts.it_supporter_app.customTools;

import android.content.Context;
import android.content.Intent;
import android.support.annotation.NonNull;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.odts.it_supporter_app.R;

import com.odts.it_supporter_app.models.Request;
import com.willy.ratingbar.ScaleRatingBar;

import java.util.List;

public class RatingAdapter extends RecyclerView.Adapter<RatingAdapter.MyViewHolder> {


    private Context context;
    private List<Request> listRating;


    public class MyViewHolder extends RecyclerView.ViewHolder {
        public TextView requestName, agencyName, feedback;
        public ScaleRatingBar ratingBar;
        public MyViewHolder(View view) {
            super(view);
            requestName = (TextView) view.findViewById(R.id.txtRequestNameRate);
            agencyName = (TextView) view.findViewById(R.id.txtAgencyNameRate);
            feedback = (TextView) view.findViewById(R.id.txtFeedbackRate);
            ratingBar = (ScaleRatingBar) view.findViewById(R.id.simpleRatingBarRate);
            ratingBar.setClickable(false);
        }
    }

    public RatingAdapter(Context context, List<Request> listRating) {
        this.context = context;
        this.listRating = listRating;
    }

    @Override
    public RatingAdapter.MyViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View itemView = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.rating_item, parent, false);
        return new RatingAdapter.MyViewHolder(itemView);
    }

    @Override
    public void onBindViewHolder(final RatingAdapter.MyViewHolder holder, int position) {
        Request request = listRating.get(position);
        holder.requestName.setText(listRating.get(position).getRequestName());
        holder.agencyName.setText(listRating.get(position).getAgencyName());
        holder.feedback.setText(listRating.get(position).getFeedBack());
        holder.ratingBar.setRating(listRating.get(position).getRating());
    }

    @Override
    public int getItemCount() {
        return listRating.size();
    }
}
