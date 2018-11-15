package com.odts.it_supporter_app.apiCaller;

import com.odts.it_supporter_app.models.Guideline;
import com.odts.it_supporter_app.utils.ResponseObject;
import com.odts.it_supporter_app.utils.ResponseObjectReturnList;

import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Query;

public interface IGuidelineApiCaller {
    @GET("ITsupporter/view_guideline")
    Call<ResponseObjectReturnList<Guideline>> getGuidelineByServiceItemID(@Query("service_item_Id") int service_item_Id);
}
