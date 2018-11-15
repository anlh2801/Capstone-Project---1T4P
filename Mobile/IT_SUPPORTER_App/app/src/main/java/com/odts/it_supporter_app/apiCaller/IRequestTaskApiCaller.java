package com.odts.it_supporter_app.apiCaller;

import com.odts.it_supporter_app.models.RequestTask;
import com.odts.it_supporter_app.utils.ResponseObject;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.POST;
import retrofit2.http.Query;

public interface IRequestTaskApiCaller {
    @POST("ITsuportter/create_task_from_guidline")
    Call<ResponseObject<Integer>> createTaskFromGuidline(@Body List<RequestTask> model);
}
