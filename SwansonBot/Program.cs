﻿using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;


//t.me/MynewpErsoNall_bot

var token = "6270972551:AAFJKzOiIW-s0PlnrxWXpPNaUmZ5HF0HKFE";

var bot = new TelegramBotClient(token);

Console.WriteLine("Start " + bot.GetMeAsync().Result.FirstName);

var cts = new CancellationTokenSource();

bot.StartReceiving(


    // handle update


    async (bot, update, cancellationToken) =>
    {
        await Console.Out.WriteLineAsync(JsonConvert.SerializeObject(update));
        if (update.CallbackQuery != null)
        {
            await bot.AnswerCallbackQueryAsync(
                callbackQueryId: update.CallbackQuery.Id
                );

            await bot.DeleteMessageAsync(
                chatId: update.CallbackQuery.Message.Chat.Id,
                messageId: update.CallbackQuery.Message.MessageId
                );
            await bot.SendTextMessageAsync(
                chatId: update.CallbackQuery.Message.Chat.Id,
                text: "Pressed button: " + update.CallbackQuery.Data
                );
            return;
        }
        if (update.Message != null)
        {
            await bot.SendChatActionAsync(
                chatId: update.Message.Chat.Id,
                chatAction: ChatAction.Typing
                );
            await Task.Delay(2000);
            //ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]


            //        {​​​​​


            //            new KeyboardButton[] {​​​​​ "Search", "Get list" }​​​​​,


            //           // new KeyboardButton[] {​​​​​ "1", "2", "3" }​​​​​,


            //        }​​​​​)


            //{​​​​​


            //


            //


            //  ResizeKeyboard = true


            //}​​​​​;

            InlineKeyboardMarkup inlineKeyboard = new(new[]


{


    // first row


    new []


    {


        InlineKeyboardButton.WithCallbackData(text: "Hello", callbackData: "hello-callback-data"),


        InlineKeyboardButton.WithCallbackData(text: "World", callbackData: "world-callback-data"),


    },


            });

            //Send text message


            await bot.SendTextMessageAsync(


                chatId: update.Message.Chat.Id,


                text: "Menu",


                parseMode: ParseMode.Markdown,


                replyMarkup: inlineKeyboard


                );





            //Send file


            //var file = "C:\\Users\\kvvkv\\source\\repos\\SwansonParser2023\\SwansonParser2023\\bin\\Debug\\net6.0\\products.xlsx";


            //await using Stream stream = System.IO.File.OpenRead(file);


            //await bot.SendDocumentAsync(


            //    chatId: update.Message.Chat.Id,


            //    document: InputFile.FromStream(stream: stream, fileName: "products.xlsx"),


            //    caption: "List of products");




            //Send photo with caption


            //var text = "1234";


            //await bot.SendPhotoAsync(


            //    chatId: update.Message.Chat.Id,


            //    photo: InputFile.FromUri("https://media.swansonvitamins.com/images/items/master/SW1876.jpg"),


            //    caption:


            //    $"<b>{​​​​​text}​​​​​ Swanson Premium- Multi with Iron + Stress Relief</b>\n" +


            //    "$15.99\n",


            //    parseMode: ParseMode.Html,


            //    replyMarkup: new InlineKeyboardMarkup(


            //            InlineKeyboardButton.WithUrl(


            //                text: "Open on site",


            //                url: "https://www.swansonvitamins.com/p/swanson-premium-multi-iron-stress-relief-60-tabs"))


            //    );


        }


    },


    // handle error


    async (bot, exeption, cancellationToken) =>


    {


        await Console.Out.WriteLineAsync(exeption.Message);


    },


    // option 


    new Telegram.Bot.Polling.ReceiverOptions { AllowedUpdates = { } },


    // cancelatiin token
    cts.Token
    );

Console.ReadLine();

//var bot = new TelegramBotClient(token);

//Console.WriteLine("Start " + bot.GetMeAsync().Result.FirstName);

//var cts = new CancellationTokenSource();

//bot.StartReceiving(
//    async (bot, update, CancellationToken) =>
//    {
//        await Console.Out.WriteLineAsync(JsonConvert.SerializeObject(update));

//        if (update.CallbackQuery != null)
//        {
//            await bot.AnswerCallbackQueryAsync(
//                callbackQueryId: update.CallbackQuery.Id
//                );

//            await bot.DeleteMessageAsync(
//                chatId: update.CallbackQuery.Message.Chat.Id,
//                messageId: update.CallbackQuery.Message.MessageId
//                );

//            await bot.SendTextMessageAsync(
//                chatId: update.CallbackQuery.Message.Chat.Id,
//                text: "Pressed button: " + update.CallbackQuery.Data
//                );

//            return;
//        }

//        if (update.Message != null)
//        {
//            await bot.SendPhotoAsync(
//                chatId: update.Message.Chat.Id,
//                photo: InputFile.FromUri("https://media.swansonvitamins.com/images/items/master/SW1876.jpg"),
//                caption:
//                "<b>Swaanson Premium- Multi with Iron + Stress Relief</b>\n" +
//                "$15.99\n" +
//                "<a href=\"https://www.swansonvitamins.com/p/swanson-premium-multi-iron-stress-relief-60-tabs \">Open</a> \n",
//                parseMode: Telegram.Bot.Types.Enums.ParseMode.Html
//                );
//        }
//    },
//    async (bot, exeption, cancellationToken) =>
//    {
//        await Console.Out.WriteLineAsync(exeption.Message);
//    },

//    new Telegram.Bot.Polling.ReceiverOptions { AllowedUpdates = { } },
//    cts.Token

//    );

//Console.ReadLine();