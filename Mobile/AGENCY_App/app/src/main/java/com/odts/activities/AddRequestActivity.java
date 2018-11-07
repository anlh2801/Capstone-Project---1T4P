package com.odts.activities;

import android.content.DialogInterface;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.LinearLayout;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.Spinner;

import com.abdeveloper.library.MultiSelectDialog;
import com.abdeveloper.library.MultiSelectModel;
import com.odts.models.Device;
import com.odts.models.Request;
import com.odts.models.ServiceITSupport;
import com.odts.models.ServiceItem;
import com.odts.models.Ticket;
import com.odts.services.DeviceService;
import com.odts.services.RequestService;
import com.odts.services.ServiceITSupportService;
import com.odts.services.ServiceItemService;
import com.odts.utils.CallBackData;

import java.util.ArrayList;
import java.util.List;

public class AddRequestActivity extends AppCompatActivity {
    private ServiceITSupportService _serviceITSupportService;
    private ServiceItemService _serviceItem;
    private DeviceService _deviceService;
    private  RequestService _requestService;
    Integer agencyId = 0;
    int serviceItemId;
    Button btnSave;
    String requestName;
    List<Device> listDv;
    ImageButton show_dialog_btn;
    ArrayList<Device> listTicket;
    String reQ;
    EditText deviceText;

    MultiSelectDialog multiSelectDialog;
    EditText txtRequestDesciption;
    EditText userInputDialogEditText;
    boolean[] mSelection = null;
    String[] _items = null;
    RadioGroup rg;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_add_request);

        SharedPreferences share = getApplicationContext().getSharedPreferences("ODTS", 0);
        SharedPreferences.Editor edit = share.edit();
        agencyId = share.getInt("agencyId", 0);

        getAllServiceITSupportForAgency(agencyId);
        btnSave = (Button) findViewById(R.id.btnSaveee);
        List<Device> listDv = new ArrayList<>();
        btnSave.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                createRequest();
            }
        });
        show_dialog_btn = findViewById(R.id.show_dialog);
        deviceText = (EditText)findViewById(R.id.listDevice);
        txtRequestDesciption = (EditText) findViewById(R.id.txtRequestDesciptionadd);
        txtRequestDesciption.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                LayoutInflater layoutInflaterAndroid = LayoutInflater.from(AddRequestActivity.this);
                View mView = layoutInflaterAndroid.inflate(R.layout.user_input_dialog_box, null);
                AlertDialog.Builder alertDialogBuilderUserInput = new AlertDialog.Builder(AddRequestActivity.this);
                alertDialogBuilderUserInput.setView(mView);

                userInputDialogEditText = (EditText) mView.findViewById(R.id.userInputDialog);
                alertDialogBuilderUserInput
                        .setCancelable(false)
                        .setPositiveButton("OK", new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialogBox, int id) {
                                // ToDo get user input here
//                                reQ = userInputDialogEditText.getText().toString();

                                txtRequestDesciption.setText(userInputDialogEditText.getText().toString());
                            }
                        })

                        .setNegativeButton("Cancel",
                                new DialogInterface.OnClickListener() {
                                    public void onClick(DialogInterface dialogBox, int id) {
                                        dialogBox.cancel();
                                    }
                                });

                AlertDialog alertDialogAndroid = alertDialogBuilderUserInput.create();
                alertDialogAndroid.show();
            }
        });
    }

    private void getAllServiceITSupportForAgency(int agencyId) {
        _serviceITSupportService = new ServiceITSupportService();
        _serviceITSupportService.getAllServiceITSupport(this, agencyId, new CallBackData<ArrayList<ServiceITSupport>>() {
            @Override
            public void onSuccess(ArrayList<ServiceITSupport> serviceITSupports) {
                LinearLayout layout = (LinearLayout) findViewById(R.id.layout_ServicesHome);

                // Load ServiceItem của Service đầu tiên
                getAllServiceItemByServiceId(serviceITSupports.get(0).getServiceITSupportId());
                getAllDeviceByAgencyIdAndServiceItem(3, (serviceITSupports.get(0).getServiceITSupportId()));
//                RadioGroup fr = new RadioGroup(AddRequestActivity.this);
//                fr.setOrientation(RadioGroup.HORIZONTAL);
                rg = (RadioGroup) findViewById(R.id.rgDevide);
                int i =0;
                for (final ServiceITSupport item : serviceITSupports) {
                    LinearLayout.LayoutParams params = new LinearLayout.LayoutParams(
                            LinearLayout.LayoutParams.WRAP_CONTENT, LinearLayout.LayoutParams.MATCH_PARENT);
                    params.weight = 1.0f;

                    RadioButton bt = new RadioButton(AddRequestActivity.this);
//                    bt.setLayoutParams(params);
                    bt.setText(item.getServiceName());
                    bt.setId(i);
                    i++;
                    rg.addView(bt);
                    rg.check(0);
                    final int serviceId = item.getServiceITSupportId();
                    bt.setOnClickListener(new View.OnClickListener() {
                        @Override
                        public void onClick(View view) {
                            getAllServiceItemByServiceId(serviceId);
                            getAllDeviceByAgencyIdAndServiceItem(3, serviceId);
                        }
                    });

                }
//                layout.addView(fr);
            }

            @Override
            public void onFail(String message) {

            }
        });
    }

    public void getAllServiceItemByServiceId(final int serviceId) {
        _serviceItem = new ServiceItemService();
        _serviceItem.getAllServiceItemByServiceId(this, serviceId, new CallBackData<ArrayList<ServiceItem>>() {
            @Override
            public void onSuccess(ArrayList<ServiceItem> serviceItems) {
                Spinner spinner = (Spinner) findViewById(R.id.spinner);
                List<ServiceItem> categories = new ArrayList<ServiceItem>();
                for (ServiceItem item : serviceItems) {
                    categories.add(item);
                }
                final ArrayAdapter<ServiceItem> dataAdapter = new ArrayAdapter<ServiceItem>(AddRequestActivity.this, android.R.layout.simple_spinner_item, categories);
                dataAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
                spinner.setAdapter(dataAdapter);
                spinner.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
                    @Override
                    public void onItemSelected(AdapterView<?> adapterView, View view, int i, long l) {
                        ServiceItem serviceItem = (ServiceItem) adapterView.getSelectedItem();
                        serviceItemId = serviceItem.getServiceItemId();
                        requestName = serviceItem.getServiceItemName();
                    }
                    @Override
                    public void onNothingSelected(AdapterView<?> adapter) {  }
                });
            }

            @Override
            public void onFail(String message) {

            }
        });
    }

    private void getAllDeviceByAgencyIdAndServiceItem(int agencyId, int serviceId) {
        _deviceService = new DeviceService();
        final ArrayList<MultiSelectModel> listOfCountries= new ArrayList<>();
        LinearLayout layout = (LinearLayout) findViewById(R.id.layout_ServicesHome);
        _deviceService.getAllDeviceByAgencyIdAndServiceItem(AddRequestActivity.this, agencyId, serviceId, new CallBackData<ArrayList<Device>>() {
            @Override
            public void onSuccess(ArrayList<Device> devices) {

                for (int i =0; i< devices.size(); i++) {
                    listOfCountries.add(new MultiSelectModel(devices.get(i).getDeviceId(),devices.get(i).getDeviceName()));
                }
                final ArrayList<Integer> alreadySelectedCountries = new ArrayList<>();
                show_dialog_btn.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View view) {
                        multiSelectDialog = new MultiSelectDialog()
                                .title("Thiết bị") //setting title for dialog
                                .titleSize(25)
                                .positiveText("OK")
                                .negativeText("Cancel")
                                .setMinSelectionLimit(0)
                                .setMaxSelectionLimit(listOfCountries.size())
                                .preSelectIDsList(alreadySelectedCountries) //List of ids that you need to be selected
                                .multiSelectList(listOfCountries) // the multi select model list with ids and name
                                .onSubmit(new MultiSelectDialog.SubmitCallbackListener() {
                                    @Override
                                    public void onSelected(ArrayList<Integer> selectedIds, ArrayList<String> selectedNames, String dataString) {
                                        //will return list of selected IDS
                                        listTicket= new ArrayList<>();
                                        Device tic = new Device();
                                        for (int i = 0; i < selectedIds.size(); i++) {
                                            tic.setDeviceId(selectedIds.get(i));
//                                            Toast.makeText(AddRequestActivity.this, "Selected Ids : " + selectedIds.get(i) + "\n" +
//                                                    "Selected Names : " + selectedNames.get(i) + "\n" +
//                                                    "DataString : " + dataString, Toast.LENGTH_SHORT).show();
//                                            alreadySelectedCountries.add(selectedIds.get(i));
                                            listTicket.add(tic);
                                        }
                                        StringBuilder sb = new StringBuilder();
                                        boolean foundOne = false;
                                        for (int i = 0; i < selectedIds.size(); ++i) {
//                                            if (mSelection[i]) {
                                                if (foundOne) {
                                                    sb.append(", ");
                                                }
                                                foundOne = true;

                                                sb.append(selectedNames.get(i));
//                                            }
                                        }
                                        deviceText.setText(sb.toString());
                                    }

                                    @Override
                                    public void onCancel() {


                                    }
                                });
                        multiSelectDialog.show(getSupportFragmentManager(), "multiSelectDialog");


                    }


                });
            }

            @Override
            public void onFail(String message) {

            }
        });
    }
    public void createRequest() {
        _requestService = new RequestService();
        List listTickett = new ArrayList<Ticket>();
        for (Device item : listTicket) {
            Ticket ticc = new Ticket();
            ticc.setDeviceId(item.getDeviceId());
            ticc.setDesciption("Thuộc agencyId: " + agencyId + " thiết bị: " + item.getDeviceName() + "Vấn đề: " + requestName.toString());
            listTickett.add(ticc);
        }

        Request request = new Request();
        request.setPhoneNumber("11111111");
        request.setAgencyId(agencyId);
        request.setRequestCategoryId(3);
        request.setServiceItemId(serviceItemId);
        request.setRequestDesciption(txtRequestDesciption.getText().toString());
        request.setRequestName(requestName.toString());
        request.setTicket(listTickett);

        _requestService.createRequest(AddRequestActivity.this, request);
    }

}
